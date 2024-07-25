using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.Networking;
using UnityEditor;

public class NUSModsAPITests
{
    private NUSModsAPI nusModsAPI;
    private string sampleJson = "[{\"moduleCode\": \"CS2003\",\"title\": \"Exchange CS Course\",\"description\": \"Available\",\"moduleCredit\": \"4\",\"department\": \"Computer Science\",\"faculty\": \"Computing\",\"workload\": [2, 2, 2, 2, 2],\"attributes\": {\"su\": true},\"gradingBasisDescription\": \"Graded\",\"semesterData\": []}]";
    ModuleInfo sampleModuleInfo = new ModuleInfo
    {
        moduleCode = "CS2003",
        title = "Exchange CS Course",
        description = "Available",
        moduleCredit = "4",
        department = "Computer Science",
        faculty = "Computing",
        workload = new List<int> { 2, 2, 2, 2, 2 },
        gradingBasisDescription = "Graded",
        semesterData = new List<SemesterData>()
    };  

    [SetUp]
    public void Setup()
    {
        nusModsAPI = new GameObject().AddComponent<NUSModsAPI>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(nusModsAPI.gameObject);
    }

    [Test]
    public void DeserializeJson()
    {
        var moduleArray = nusModsAPI.DeserializeJson(sampleJson);
        Assert.IsNotNull(moduleArray);
        Assert.AreEqual(1, moduleArray.items.Length);
        Assert.AreEqual("CS2003", moduleArray.items[0].moduleCode);
    }

    [Test]
    public void ProcessModuleData()
    {
        nusModsAPI.ProcessModuleData(sampleJson);
        var modules = nusModsAPI.GetModulesByType("Computing", 10);
        Assert.AreEqual(1, modules.Count);
        Assert.AreEqual("CS2003", modules[0].moduleName);
    }

    [Test]
    public void CreateModuleScriptableObject()
    {
        nusModsAPI.CreateModuleScriptableObject(sampleModuleInfo);
        string path = $"Assets/ScriptableObjects/Modules/CS2003.asset";
        Module createdModule = AssetDatabase.LoadAssetAtPath<Module>(path);
        Assert.IsNotNull(createdModule);
        Assert.AreEqual("CS2003", createdModule.moduleName);
    }

    [Test]
    public void IsAllowedModule()
    {
        List<string> allowedFaculties = nusModsAPI.GetAllowedFaculties();
        Dictionary<string, int> facultyCourseCount = new Dictionary<string, int>
        {
            { "Computing", 0 }
        };

        ModuleInfo sampleModuleInfo = new ModuleInfo
        {
            moduleCode = "CS2003",
            title = "Exchange CS Course",
            description = "Valid Description",
            moduleCredit = "4",
            department = "Computer Science",
            faculty = "Computing",
            workload = new List<int> { 2, 2, 2, 2, 2 },
            gradingBasisDescription = "Graded",
            semesterData = new List<SemesterData>()
        };

        // Check for a valid module
        var result = nusModsAPI.IsAllowedModule(sampleModuleInfo, allowedFaculties, facultyCourseCount);
        Assert.IsTrue(result.isAllowed, result.failedCondition);

        sampleModuleInfo.faculty = "Invalid Faculty";
        result = nusModsAPI.IsAllowedModule(sampleModuleInfo, allowedFaculties, facultyCourseCount);
        Assert.IsFalse(result.isAllowed);
        Assert.AreEqual("Faculty not allowed", result.failedCondition);

        sampleModuleInfo.faculty = "Computing";
        facultyCourseCount["Computing"] = 80 * 5;
        result = nusModsAPI.IsAllowedModule(sampleModuleInfo, allowedFaculties, facultyCourseCount);
        Assert.IsFalse(result.isAllowed);
        Assert.AreEqual("Faculty course limit exceeded", result.failedCondition);

        facultyCourseCount["Computing"] = 0;
        sampleModuleInfo.workload = null;
        result = nusModsAPI.IsAllowedModule(sampleModuleInfo, allowedFaculties, facultyCourseCount);
        Assert.IsFalse(result.isAllowed);
        Assert.AreEqual("Invalid workload", result.failedCondition);

        sampleModuleInfo.workload = new List<int> { 2, 2, 2, 2, 2 };
        sampleModuleInfo.moduleCredit = "3";
        result = nusModsAPI.IsAllowedModule(sampleModuleInfo, allowedFaculties, facultyCourseCount);
        Assert.IsFalse(result.isAllowed);
        Assert.AreEqual("Module credit too low", result.failedCondition);

        sampleModuleInfo.moduleCredit = "4";
        sampleModuleInfo.description = "Not Available";
        result = nusModsAPI.IsAllowedModule(sampleModuleInfo, allowedFaculties, facultyCourseCount);
        Assert.IsFalse(result.isAllowed);
        Assert.AreEqual("Description not available", result.failedCondition);

        sampleModuleInfo.description = "Valid Description";
        sampleModuleInfo.workload = new List<int> { 1, 1, 1, 1, 1 };
        result = nusModsAPI.IsAllowedModule(sampleModuleInfo, allowedFaculties, facultyCourseCount);
        Assert.IsFalse(result.isAllowed);
        Assert.AreEqual("Difficulty too low", result.failedCondition);
    }
    
    [UnityTest]
    public IEnumerator FetchModuleData()
    {
        UnityWebRequest request = UnityWebRequest.Get("https://api.nusmods.com/v2/2023-2024/moduleInfo.json");
        yield return request.SendWebRequest();

        Assert.AreEqual(UnityWebRequest.Result.Success, request.result);

        nusModsAPI.ProcessModuleData(request.downloadHandler.text);
        var modules = nusModsAPI.GetModulesByType("Computing", 10);
        Assert.IsTrue(modules.Count > 0);
    }
}
