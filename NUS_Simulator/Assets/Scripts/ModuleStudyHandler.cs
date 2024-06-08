using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using System.Xml;

// ModuleStudyHandler.cs
public class ModuleStudyHandler : MonoBehaviour
{
    [SerializeField] private ModuleData moduleData;
    [SerializeField] private GameObject progressBarPanel;
    [SerializeField] private Transform panelParent;
    [SerializeField] private Button startButton;
    [SerializeField] private Button stopButton;
    [SerializeField] private TextMeshProUGUI warningText;

    private GameObject[] modulePanels;
    private ProgressBar[] progressBars;

    void Start()
    {
        progressBarPanel.SetActive(false);
        warningText.gameObject.SetActive(false);
        UpdateModuleButtons();
        InitializeModulePanelsAndProgressBars();
        StudyManager.Instance.SetProgressBars(progressBars);
    }

    void UpdateModuleButtons()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            int buttonIndex;
            if (int.TryParse(button.name, out buttonIndex))
            {
                Module assignedModule = moduleData.GetModule(buttonIndex);
                if (assignedModule != null)
                {
                    TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
                    if (buttonText != null)
                    {
                        buttonText.text = assignedModule.GetModuleName();
                        Debug.Log("Assigned module: " + assignedModule.GetModuleName() + " to button: " + buttonIndex);
                    }
                    else
                    {
                        Debug.LogWarning("Text component not found in button: " + button.name);
                    }
                }
                else
                {
                    Debug.Log("No module assigned to button index: " + buttonIndex);
                }
            }
        }
    }

    public void ClickOnModule()
    {
        warningText.gameObject.SetActive(true);
        Button clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        if (StudyManager.Instance.IsStudying())
        {
            return;
        }
        string clickedButtonModule = clickedButton.name;
        progressBarPanel.SetActive(false);
        int buttonIndex;
        if (int.TryParse(clickedButtonModule, out buttonIndex))
        {
            if (buttonIndex >= 0 && buttonIndex < modulePanels.Length)
            {
                for (int i = 0; i < modulePanels.Length; i++)
                {
                    modulePanels[i].SetActive(false);
                    progressBars[i].StopProgress();
                }
                if (StudyManager.Instance.GetActiveModuleIndex() != -1)
                {
                    progressBars[StudyManager.Instance.GetActiveModuleIndex()].StopProgress();
                }

                // progressBars[buttonIndex].StartProgress();
        
                ModuleProgressValue moduleProgress = StudyManager.Instance.GetModuleProgress(buttonIndex);
                ProgressBar progressBar = progressBars[buttonIndex];
                progressBar.SetModuleProgress(moduleProgress); 

                Module module = moduleData.GetModule(buttonIndex);
                progressBar.SetModuleSideText(module.GetModuleName());

                modulePanels[buttonIndex].SetActive(true);

                StudyManager.Instance.SwitchModule(buttonIndex);
                
            }
        }
    }

    private void InitializeModulePanelsAndProgressBars()
    {
        int moduleCount = moduleData.GetAllModules().Length;
        modulePanels = new GameObject[moduleCount];
        progressBars = new ProgressBar[moduleCount];

        for (int i = 0; i < moduleCount; i++)
        {
            GameObject panel = Instantiate(progressBarPanel, panelParent);
            panel.SetActive(false);
            modulePanels[i] = panel;

            ProgressBar progressBar = panel.GetComponentInChildren<ProgressBar>();
            if (progressBar != null)
            {
                ModuleProgressValue moduleProgress = StudyManager.Instance.GetModuleProgress(i);
                progressBar.SetModuleProgress(moduleProgress);
                progressBars[i] = progressBar;
            }
            else
            {
                Debug.LogWarning("ProgressBar component not found in panel: " + panel.name);
            }
        }
    }

    public void OnStartButtonClick()
    {
        Debug.Log("Start button clicked");
        int activeModuleIndex = StudyManager.Instance.GetActiveModuleIndex();
        if (activeModuleIndex != -1)
        {
            Debug.Log("Starting study for module: " + activeModuleIndex);
            StudyManager.Instance.StartStudying(activeModuleIndex);
        }
    }

    public void OnStopButtonClick()
    {
        Debug.Log("Stop button clicked");
        int activeModuleIndex = StudyManager.Instance.GetActiveModuleIndex();
        if (activeModuleIndex != -1)
        {
            Debug.Log("Stopping study for module: " + activeModuleIndex);
            StudyManager.Instance.StopStudying();
    
        }
    }

    public void OnBackButtonClick() 
    {
        // makes all the progress bars stop
        if (progressBars != null)
        {
            for (int i = 0; i < progressBars.Length; i++)
            {
                if (progressBars[i] != null)
                {
                    Debug.Log($"Saving progress for progress bar {i}");
                    progressBars[i].SaveProgress();
                }
                else
                {
                    Debug.LogWarning($"Progress bar {i} is null");
                }
            }
        }
        StudyManager.Instance.StopStudying();
        SceneManager.LoadScene("InGameScene"); 
    }
}
