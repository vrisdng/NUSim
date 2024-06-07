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
        if (progressBar != null)
        {
            progressBar.fillAmount = 0.0f;
            progressText.text = "0%";
        }
        isUpdating = false;
    }

    void Update()
    {
        if (isUpdating && moduleProgressValue != null) 
        {
            UpdateModuleProgress();
        }
    }

    public void UpdateModuleProgress()
    {
        if (moduleProgressValue != null && moduleProgressValue.Progress < moduleProgressValue.MaxTime)
        {
            moduleProgressValue.SetProgress(moduleProgressValue.Progress + Time.deltaTime);
            progressBar.fillAmount = moduleProgressValue.GetProgressPercentage();
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

    public void CloseWorkPanel()
    {
        SceneManager.LoadScene("InGameScreen");
    }
}
