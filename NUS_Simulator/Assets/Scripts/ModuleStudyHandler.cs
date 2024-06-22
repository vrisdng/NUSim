using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using System.Xml;

// ModuleStudyHandler.cs
/* 
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

    public PlayerInfoDisplay playerInfoDisplay;
    public PointsController PointsController;

    void Start()
    {
        playerInfoDisplay.DisplayPlayerInfo();
        PointsController.Initialize(Student.Instance);
        progressBarPanel.SetActive(false);
        warningText.gameObject.SetActive(false);
        UpdateModuleButtons();
        InitializeModulePanelsAndProgressBars();
        StudyManager.Instance.SetProgressBars(progressBars);
    }

void UpdateModuleButtons()
{
    Button[] buttons = GetComponentsInChildren<Button>();
    Module[] selectedModules = SelectedModulesManager.Instance.SelectedModules;
    
    for (int i = 0; i < buttons.Length; i++)
    {
        if (i < selectedModules.Length)
        {
            Module assignedModule = selectedModules[i];
            TextMeshProUGUI buttonText = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.text = assignedModule.GetModuleName();
                Debug.Log("Assigned module: " + assignedModule.GetModuleName() + " to button: " + i);
            }
            else
            {
                Debug.LogWarning("Text component not found in button: " + buttons[i].name);
            }
        }
        else
        {
            buttons[i].gameObject.SetActive(false);
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
    string clickedButtonName = clickedButton.name;
    progressBarPanel.SetActive(false);
    int buttonIndex;
    if (int.TryParse(clickedButtonName, out buttonIndex))
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

            Module selectedModule = SelectedModulesManager.Instance.SelectedModules[buttonIndex];
            ProgressBar progressBar = progressBars[buttonIndex];
            progressBar.SetModule(selectedModule);

            modulePanels[buttonIndex].SetActive(true);

            StudyManager.Instance.SwitchModule(buttonIndex);
        }
    }
}


    private void InitializeModulePanelsAndProgressBars()
    {
        Module[] selectedModules = SelectedModulesManager.Instance.SelectedModules;
        int moduleCount = selectedModules.Length;
        modulePanels = new GameObject[moduleCount];
        progressBars = new ProgressBar[moduleCount];

        for (int i = 0; i < moduleCount; i++)
        {
            GameObject panel = Instantiate(progressBarPanel, panelParent);
            panel.SetActive(false);
            modulePanels[i] = panel;

            ProgressBar progressBar = panel.GetComponentInChildren<ProgressBar>();
            progressBar.SetModule(selectedModules[i]);
            progressBars[i] = progressBar;
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

    public void CloseWorkPanel()
    {
        SceneManager.LoadScene("InGameScreen");
    }
}
*/