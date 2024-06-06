using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ModuleStudyHandler : MonoBehaviour {
    [SerializeField] private ModuleData moduleData; // Reference to the ModuleData ScriptableObject
    [SerializeField] private GameObject progressBarPanel;
    [SerializeField] private Transform panelParent;

    private GameObject[] modulePanels;
    private ProgressBar[] progressBars;
    private int activeModuleIndex = -1; 
    void Start() {
        UpdateModuleButtons();
        InitializeModulePanelsAndProgressBars();
    }

    void Update() {
        if (activeModuleIndex != -1) {
            Module activeModule = moduleData.GetModule(activeModuleIndex);
            float progressSpeed = activeModule.GetModuleDifficulty(); // Assuming difficulty represents speed
            progressBars[activeModuleIndex].UpdateModuleProgress(progressSpeed);
        }
    }

    void UpdateModuleButtons() {
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach (Button button in buttons) {
            int buttonIndex;
            if (int.TryParse(button.name, out buttonIndex)) {
                Module assignedModule = moduleData.GetModule(buttonIndex);
                if (assignedModule != null) {
                    TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
                    if (buttonText != null) {
                        buttonText.text = assignedModule.GetModuleName();
                        Debug.Log("Assigned module: " + assignedModule.GetModuleName() + " to button: " + buttonIndex);
                    } else {
                        Debug.LogWarning("Text component not found in button: " + button.name);
                    }
                } else {
                    Debug.Log("No module assigned to button index: " + buttonIndex);
                }
            }
        }
    }

    public void ClickOnModule() {
        Button clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        string clickedButtonModule = clickedButton.name;

        // Parse the button name to get the index
        int buttonIndex;
        if (int.TryParse(clickedButtonModule, out buttonIndex)) {
            if (buttonIndex >= 0 && buttonIndex < modulePanels.Length) {
                // Deactivate all panels
                for (int i = 0; i < modulePanels.Length; i++) {
                    modulePanels[i].SetActive(false);
                    progressBars[i].StopProgress(); 
                }

                // Activate the selected panel
                modulePanels[buttonIndex].SetActive(true);
                progressBars[buttonIndex].StartProgress(); 

                // Set the progress for the selected panel
                ModuleProgressValue moduleProgress = moduleData.GetModuleProgress(buttonIndex);
                ProgressBar progressBar = progressBars[buttonIndex];
                progressBar.SetModuleProgress(moduleProgress);

                Module module = moduleData.GetModule(buttonIndex);
                progressBar.SetModuleSideText(module.GetModuleName());

                activeModuleIndex = buttonIndex;
            }
        }
    }

    private void InitializeModulePanelsAndProgressBars() {
        int moduleCount = moduleData.GetAllModules().Length;
        modulePanels = new GameObject[moduleCount];
        progressBars = new ProgressBar[moduleCount];

        for (int i = 0; i < moduleCount; i++) {
            GameObject panel = Instantiate(progressBarPanel, panelParent);
            panel.SetActive(false);
            modulePanels[i] = panel;

            ProgressBar progressBar = panel.GetComponentInChildren<ProgressBar>();
            if (progressBar != null) {
                ModuleProgressValue moduleProgress = moduleData.GetModuleProgress(i);
                if (moduleProgress == null) {
                    moduleProgress = ScriptableObject.CreateInstance<ModuleProgressValue>();
                    moduleProgress.Initialize(25.0f); // Example maxTime value
                    moduleData.moduleProgressValues[i] = moduleProgress;
                }
                Debug.Log("Max time for module " + i + ": " + moduleProgress.GetMaxTime());
                progressBar.SetModuleProgress(moduleProgress);
                progressBars[i] = progressBar;
            } else {
                Debug.LogWarning("ProgressBar component not found in panel: " + panel.name);
            }
        }
    }

    public void DisablePanels() {
        panelParent.gameObject.SetActive(false);
    }
}