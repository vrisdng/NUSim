using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModuleManager : MonoBehaviour
{
    public Button moduleButton;
    public GameObject nextButton; 
    public List<Module> availableModules = new List<Module>();
    public Transform[] moduleSlots;

    private Module[] selectedModules = new Module[5];
    private int clickedCount = 0;

    void Awake()
    {
        CreateModuleButtons();
        nextButton.SetActive(false);
    }

    List<Module> FilterUncompletedModules(List<Module> availableModules)
    {
        List<Module> uncompletedModules = new List<Module>();
        foreach (Module module in availableModules)
        {
            if (!module.isCompleted)
            {
                uncompletedModules.Add(module);
            }
        }
        return uncompletedModules;
    }

    public void CreateModuleButtons()
    {
        availableModules = FilterUncompletedModules(availableModules);
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

    public void OnModuleButtonClick(Module module, Button button)
    {
        if (clickedCount > 5)
        {
            Debug.Log("Maximum of 5 modules have already been selected.");
        }
        
        button.interactable = false;
        selectedModules[clickedCount] = module;
        clickedCount++;
        Debug.Log($"Module selected: {module.moduleName}");
        nextButton.SetActive(false);

        if (clickedCount == 5)
        {
            SelectedModulesManager.Instance.SetSelectedModules(selectedModules);
            Debug.Log("Selected modules have been set in the singleton.");
            nextButton.SetActive(true);
        }
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
