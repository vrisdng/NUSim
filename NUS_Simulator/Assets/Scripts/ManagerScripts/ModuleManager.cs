using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModuleManager : MonoBehaviour
{
    public Button moduleButton;
    public Button nextButton;
    public List<Module> availableModules = new List<Module>();
    public Transform[] moduleSlots;
    public Module[] selectedModules; 

    [SerializeField] public TextMeshProUGUI moduleName;
    [SerializeField] public TextMeshProUGUI moduleTitle;
    [SerializeField] public TextMeshProUGUI moduleType;
    [SerializeField] public TextMeshProUGUI moduleDifficulty;
    public GameObject moduleInfoPanel;
    public Button takeModuleButton;
    public Button goBackButton;
    private int clickedCount = 0;
    private Student PLAYER = Student.Instance;

    void Start()
    {
        string faculty = CreateCharacterScript.facultyChosen; 
        Debug.Log("Player's faculty: " + faculty);
        LoadAvailableModules(faculty); 
        Debug.Log("Player's faculty: " + PLAYER.GetFaculty());
        CreateModuleButtons();
        selectedModules = new Module[5];
        nextButton.interactable = false;
        moduleInfoPanel.SetActive(false);
    }

    public void LoadAvailableModules(string moduleType)
    {
        Debug.Log("Loading modules...");
        availableModules.Clear();
        Module[] modules = Resources.LoadAll<Module>("Modules");

        foreach (Module module in modules)
        {
            if (module != null && module.moduleType == moduleType && module.isCompleted == false && module.moduleDepartment != "Information Systems and Analytics" && module.moduleDepartment != "SoC Dean's Office")
            {
                Debug.Log(module.moduleDepartment);
                availableModules.Add(module);
                if (availableModules.Count >= 10)
                {
                    break;
                }
            }
        }
        Debug.Log("Modules loaded: " + availableModules.Count);
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
        moduleDifficulty.text = "Module's Difficulty:  " + (module.moduleDifficulty / 10).ToString();
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
        //ResetModuleButtons();
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

    public void CompleteSelectedModules()
    {
        foreach (Module module in selectedModules)
        {
            if (module != null)
            {
                module.SetCompleted(true);
            }
        }
    }
}
