using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class ModuleManager : MonoBehaviour
{
    public Button moduleButton;
    public Button nextButton; 
    public List<Module> availableModules = new List<Module>();
    public Transform[] moduleSlots;

    public Module[] selectedModules = new Module[5];
    public NUSModsAPI nusModsAPI;

    [SerializeField] public TextMeshProUGUI moduleName;
    [SerializeField] public TextMeshProUGUI moduleTitle;
    [SerializeField] public TextMeshProUGUI moduleType;
    [SerializeField] public TextMeshProUGUI moduleDifficulty;
    public GameObject moduleInfoPanel; 
    public Button takeModuleButton;
    public Button goBackButton; 
    private int clickedCount = 0;
    private Student PLAYER = Student.Instance;

    void Awake()
    {
        LoadAvailableModules(PLAYER.GetFaculty()); 
        CreateModuleButtons();
        nextButton.interactable = false;
        moduleInfoPanel.SetActive(false);
    }

    public void LoadAvailableModules(string moduleType)
    {
        availableModules.Clear();
        string[] guids = AssetDatabase.FindAssets("t:Module", new[] { "Assets/ScriptableObjects/Modules" });

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Module module = AssetDatabase.LoadAssetAtPath<Module>(path);
            if (module != null && module.moduleType == moduleType && !module.isCompleted && module.moduleDepartment != "Information Systems and Analytics" && module.moduleDepartment != "SoC Dean's Office")
            {
                Debug.Log(module.moduleDepartment); 
                availableModules.Add(module);
                if (availableModules.Count >= 10)
                {
                    break;
                }
            }
        }
    }

    public void CreateModuleButtons()
    {
        int limit = Mathf.Min(availableModules.Count, 10);

        for (int i = 0; i < limit; i++)
        {
            Module module = availableModules[i];
            Debug.Log("Progress of these modules: " + availableModules[i].GetProgress());
            Transform slot = moduleSlots[i];

            Button buttonInstance = Instantiate(moduleButton, slot);
            RectTransform buttonRect = buttonInstance.GetComponent<RectTransform>();
            buttonRect.sizeDelta = new Vector2(1044, 300);
            buttonRect.localScale = new Vector3(1f, 1f, 1f);

            buttonInstance.GetComponentInChildren<TextMeshProUGUI>().text = module.moduleName;
            buttonInstance.onClick.AddListener(() => OnModuleButtonClick(module, buttonInstance));
        }
    }

    public void SetTexts(Module module)
    {
        moduleName.text = module.moduleName;
        moduleTitle.text = "Module's Name:  " + module.moduleTitle;
        moduleType.text = "Module's Type:  " + module.moduleType;
        moduleDifficulty.text = "Module's Difficulty:  " + (module.moduleDifficulty / 10).ToString() ;
    }

    public void OnModuleButtonClick(Module module, Button button)
    {
        SetTexts(module); 
        moduleInfoPanel.SetActive(true);

        takeModuleButton.onClick.RemoveAllListeners();
        goBackButton.onClick.RemoveAllListeners();

        takeModuleButton.onClick.AddListener(() => OnTakeModuleButtonClick(module, button));
        goBackButton.onClick.AddListener(OnGoBackButtonClick);
    }

    public void OnTakeModuleButtonClick(Module module, Button button)
    {
        if (clickedCount >= 5)
        {
            Debug.Log("Maximum of 5 modules have already been selected.");
            return;
        }

        button.interactable = false; 
        selectedModules[clickedCount] = module;
        clickedCount++;
        Debug.Log($"Module selected: {module.moduleName}");

        moduleInfoPanel.SetActive(false); 

        if (clickedCount == 5)
        {
            SelectedModulesManager.Instance.SetSelectedModules(selectedModules);
            Debug.Log("Selected modules have been set in the singleton.");
            nextButton.interactable = true;
        }
    }

    public void OnGoBackButtonClick()
    {
        moduleInfoPanel.SetActive(false);
    }

    public void StartNewSemester()
    {
        clickedCount = 0;
        SelectedModulesManager.Instance.ResetSelectedModules();
        ResetModuleButtons();
    }

    public void ResetModuleButtons()
    {
        foreach (Transform slot in moduleSlots)
        {
            foreach (Button button in slot.GetComponentsInChildren<Button>())
            {
                button.interactable = true;
            }
        }
    }

    
}
