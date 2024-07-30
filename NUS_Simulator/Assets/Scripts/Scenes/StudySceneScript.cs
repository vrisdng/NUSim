using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using System.Xml;

// ModuleStudyHandler.cs
public class StudySceneScript : MonoBehaviour
{
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
        PointsController.StartDecrementPoints(1f);
        
        progressBarPanel.SetActive(false);
        warningText.gameObject.SetActive(false);
        
        UpdateModuleButtons();
        InitializeModulePanelsAndProgressBars();
        StudyManager.Instance.SetProgressBars(progressBars);
    }

    void Update()
    {
        if (Student.Instance.IsAnyPointZero()) {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    void UpdateModuleButtons()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        Module[] selectedModules = SelectedModulesManager.Instance.SelectedModules;
        
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].name == "BackButton") {
                continue;
            }
            
            UpdateButton(buttons[i], i, selectedModules);
        }
    }

    void UpdateButton(Button button, int index, Module[] selectedModules)
    {
        if (index >= selectedModules.Length)
        {
            Utils.SetVisibility(button, false);
            return;
        }
        
        Module assignedModule = selectedModules[index];
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        
        if (buttonText == null)
        {
            Debug.Log("Text component not found in button: " + button.name);
            return;
        }
        
        if (assignedModule == null)
        {
            Debug.Log("Assigned module is null");
            return;
        }
        
        Utils.SetText(buttonText, assignedModule.GetModuleName());
        Debug.Log(assignedModule.GetModuleName() + index);
    }
    public void ClickOnModule()
    {
        warningText.gameObject.SetActive(true);

        if (StudyManager.Instance.IsStudying())
        {
            return;
        }

        Button clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        string clickedButtonName = clickedButton.name;
        if (!int.TryParse(clickedButtonName, out int buttonIndex))
        {
            return;
        }

        if (buttonIndex < 0 || buttonIndex >= modulePanels.Length)
        {
            return;
        }

        progressBarPanel.SetActive(false);

        for (int i = 0; i < modulePanels.Length; i++)
        {
            modulePanels[i].SetActive(i == buttonIndex);
            progressBars[i].StopProgress();
        }

        int activeModuleIndex = StudyManager.Instance.GetActiveModuleIndex();
        if (activeModuleIndex != -1)
        {
            progressBars[activeModuleIndex].StopProgress();
        }

        Module selectedModule = SelectedModulesManager.Instance.SelectedModules[buttonIndex];
        progressBars[buttonIndex].SetModule(selectedModule);

        modulePanels[buttonIndex].SetActive(true);
        Debug.Log("Turned on module panel for module: " + buttonIndex);
        StudyManager.Instance.SwitchModule(buttonIndex);
    }

    public void InitializeModulePanelsAndProgressBars()
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
            modulePanels[i].SetActive(false); 

            ProgressBar progressBar = panel.GetComponentInChildren<ProgressBar>();
            progressBar.SetModule(selectedModules[i]);
            progressBars[i] = progressBar;
            Debug.Log("Progress bar set for module: " + i);
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
        if (progressBars == null)
        {
            Debug.LogWarning("Progress bars are null");
            return;
        }

        for (int i = 0; i < progressBars.Length; i++)
        {
            if (progressBars[i] == null)
            {
                Debug.LogWarning($"Progress bar {i} is null");
                continue;
            }

            Debug.Log($"Saving progress for progress bar {i}");
            progressBars[i].SaveProgress();
        }

        StudyManager.Instance.StopStudying();
        SceneManager.LoadScene("InGameScene");
    }

    public void CloseWorkPanel()
    {
        SceneManager.LoadScene("InGameScreen");
    }
}