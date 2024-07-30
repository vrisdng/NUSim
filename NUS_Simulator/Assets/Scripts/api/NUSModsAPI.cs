using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;
using System.Collections.Generic;
#if UNITY_EDITOR
    using UnityEditor;
#endif

#if UNITY_EDITOR
public class NUSModsAPI : MonoBehaviour
{
    private string apiUrl = "https://api.nusmods.com/v2/2023-2024/moduleInfo.json";
    private List<Module> allModules = new List<Module>();
    private const int LIMIT = 80; 

    void Start()
    {
        StartCoroutine(GetModuleData());
    }

    IEnumerator GetModuleData()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            string json = request.downloadHandler.text;
            ProcessModuleData(json);
        }
    }
    public void ProcessModuleData(string json)
    {
        ModuleInfoArray moduleArray = DeserializeJson(json);
        if (moduleArray == null || moduleArray.items == null)
        {
            Debug.LogError("Failed to deserialize JSON into ModuleInfoArray.");
            return;
        }

        List<string> allowedFaculties = GetAllowedFaculties();
        Dictionary<string, int> facultyCourseCount = new Dictionary<string, int>();
        foreach (string faculty in allowedFaculties)
        {
            facultyCourseCount[faculty] = 0;
        }

        ProcessModules(moduleArray.items, allowedFaculties, facultyCourseCount);
    }

    public ModuleInfoArray DeserializeJson(string json)
    {
        string wrappedJson = "{\"items\":" + json + "}";
        Debug.Log("Wrapped JSON: " + wrappedJson);
        return JsonUtility.FromJson<ModuleInfoArray>(wrappedJson);
    }

    public List<string> GetAllowedFaculties()
    {
        return new List<string>
        {
            "Arts and Social Science",
            "Science",
            "College of Design and Engineering",
            "Computing",
            "NUS Business School"
        };
    }

    public void ProcessModules(ModuleInfo[] modules, List<string> allowedFaculties, Dictionary<string, int> facultyCourseCount)
    {
        int count = 0; 
        foreach (ModuleInfo module in modules)
        {
            if (count >= LIMIT * 5)
            {
                break; 
            }

            var (isAllowed, failedCondition) = IsAllowedModule(module, allowedFaculties, facultyCourseCount);

            if (isAllowed)
            {
                CreateModuleScriptableObject(module);
                facultyCourseCount[module.faculty]++;
                Debug.Log("Created: " + module.moduleCode);
                count++; 
            }
            else
            {
                Debug.LogWarning($"Module {module.moduleCode} not allowed: {failedCondition}");
                continue; 
            }
        }
    }

    public (bool isAllowed, string failedCondition) IsAllowedModule(ModuleInfo module, List<string> allowedFaculties, Dictionary<string, int> facultyCourseCount)
    {
        var conditions = new Dictionary<Func<bool>, string>
        {
            { () => allowedFaculties.Contains(module.faculty), "Faculty not allowed" },
            { () => facultyCourseCount[module.faculty] < LIMIT, "Faculty course limit exceeded" },
            { () => module.workload != null && module.workload.Count > 0, "Invalid workload" },
            { () => CalculateDifficulty(module) >= 10.0f, "Difficulty too low" },
            { () => int.Parse(module.moduleCredit) >= 4, "Module credit too low" },
            { () => module.description != "Not Available", "Description not available" }
        };

        foreach (var condition in conditions)
        {
            if (!condition.Key())
            {
                return (false, condition.Value);
            }
        }

        return (true, "Passed all conditions");
    }

    public void CreateModuleScriptableObject(ModuleInfo moduleInfo)
    {
       
        string relativePath = $"Assets/Resources/Modules/{moduleInfo.moduleCode}.asset";

        Module existingModule = AssetDatabase.LoadAssetAtPath<Module>(relativePath);
        if (existingModule == null)
        {
            Module module = ScriptableObject.CreateInstance<Module>();
            module.moduleName = moduleInfo.moduleCode; 
            module.moduleTitle = moduleInfo.title;
            module.moduleDifficulty = CalculateDifficulty(moduleInfo);
            module.moduleType = moduleInfo.faculty;
            module.moduleDepartment = moduleInfo.department;
            module.moduleCredit = int.Parse(moduleInfo.moduleCredit);
            module.isCompleted = false;
            module.moduleProgress = 0.0f;
            module.isStudying = false;

            allModules.Add(module);

            AssetDatabase.CreateAsset(module, relativePath);
            AssetDatabase.SaveAssets();
        }
        else
        {
            allModules.Add(existingModule);
            Debug.LogWarning($"Module {moduleInfo.moduleCode} already exists.");
        }
    }

    public float CalculateDifficulty(ModuleInfo moduleInfo)
    {
        if (moduleInfo.workload != null && moduleInfo.workload.Count > 0)
        {
            return moduleInfo.workload[0] + moduleInfo.workload[1] + 
            moduleInfo.workload[2] + moduleInfo.workload[3] + moduleInfo.workload[4];
        }
        else
        {
            Debug.LogWarning($"Module {moduleInfo.moduleCode} has an empty or null workload list.");
            return 0.0f; 
        }
    }

    public List<Module> GetModulesByType(string moduleType, int maxCount)
    {
        List<Module> filteredModules = new List<Module>();
        foreach (Module module in allModules)
        {
            if (module.moduleType == moduleType)
            {
                filteredModules.Add(module);
            }
        }

        // sort by module credit if difficulty is the same
        filteredModules.Sort((a, b) =>
        {
            int difficultyCompare = a.moduleDifficulty.CompareTo(b.moduleDifficulty);
            if (difficultyCompare == 0) 
            {
                return a.moduleCredit.CompareTo(b.moduleCredit);
            }
            return difficultyCompare;
        });

        List<Module> result = new List<Module>();
        for (int i = 0; i < maxCount && i < filteredModules.Count; i++)
        {
            result.Add(filteredModules[i]);
        }

        return result;
    }
}

[Serializable]
public class ModuleInfo
{
    public string moduleCode;
    public string title;
    public string description;
    public string moduleCredit;
    public string department;
    public string faculty;
    public List<int> workload;
    public string gradingBasisDescription;
    public List<SemesterData> semesterData;
}

[Serializable]
public class SemesterData
{
    public int semester;
    public List<string> covidZones;
}

[Serializable]
public class ModuleInfoArray
{
    public ModuleInfo[] items;
}

#endif
