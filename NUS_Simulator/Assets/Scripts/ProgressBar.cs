using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using TMPro;


public class ProgressBar : MonoBehaviour
{
    private Image progressBar;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private TextMeshProUGUI moduleSideText;
    private ModuleProgressValue moduleProgressValue;
    private bool isUpdating;

    void Start()
    {
        progressBar = GetComponent<Image>();
        isUpdating = false;
    }

    void Update()
    {
        if (moduleProgressValue != null) {
            if (moduleProgressValue.Progress >= moduleProgressValue.MaxTime) {
                StopProgress(); 
                StudyManager.Instance.StopStudying();
            }
            if (isUpdating) {
                UpdateModuleProgress();
            }
        }
    }

    public void UpdateModuleProgress()
    {
        if (moduleProgressValue != null && moduleProgressValue.Progress < moduleProgressValue.MaxTime)
        {
            moduleProgressValue.SetProgress(moduleProgressValue.Progress + Time.deltaTime);
            progressBar.fillAmount = moduleProgressValue.GetProgressPercentage();
            Debug.Log("MPV's progress in UpdateModuleProgress: " + moduleProgressValue.Progress); 
            progressText.text = (progressBar.fillAmount * 100).ToString("F0") + "%";
        }
    }

    public void SetModuleSideText(string text)
    {
        moduleSideText.text = text;
    }

    public void SetModuleProgress(ModuleProgressValue progress)
    {
        moduleProgressValue = progress;
        if (moduleProgressValue != null)
        {
            if (progressBar == null)
            {
                progressBar = GetComponent<Image>();
            }
            progressBar.fillAmount = moduleProgressValue.GetProgressPercentage();
            progressText.text = (progressBar.fillAmount * 100).ToString("F0") + "%";
            Debug.Log(progress);
            Debug.Log("Succesfully for setModuleProgress"); 
        }
        else {
            Debug.Log("No mPV initialized"); 
        }
    }

    public void UpdateModuleProgress(float speed)
    {
        if (moduleProgressValue != null && moduleProgressValue.Progress < moduleProgressValue.MaxTime)
        {
            moduleProgressValue.SetProgress(moduleProgressValue.Progress + Time.deltaTime * speed);
            progressBar.fillAmount = moduleProgressValue.GetProgressPercentage();
            progressText.text = (progressBar.fillAmount * 100).ToString("F0") + "%";
        }
    }

    public void StartProgress()
    {
        isUpdating = true;
        Debug.Log("Succesfully start progress");
    }

    public void StopProgress()
    {
        isUpdating = false;
    }

    public void ResetProgress()
    {
        if (moduleProgressValue != null)
        {
            moduleProgressValue.ResetProgress();
            progressBar.fillAmount = 0;
            progressText.text = "0%";
        }
    }

    public void SaveProgress()
    {
        if (moduleProgressValue != null)
        {
            moduleProgressValue.SaveProgress(progressBar != null ? progressBar.fillAmount * moduleProgressValue.MaxTime : 0);
        }
        Debug.Log("Saving progress here"); 
    }

    public void CloseWorkPanel()
    {
        SceneManager.LoadScene("InGameScreen");
    }
}
