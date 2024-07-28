using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class ProgressBar : MonoBehaviour
{
    private Image progressBar;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private TextMeshProUGUI moduleSideText;
    private Module module; 
    private bool isUpdating;

    void Start()
    {
        progressBar = GetComponent<Image>();
        isUpdating = false;
    }

    void Update()
    {
        if (isUpdating)
        {
            UpdateModuleProgress();
        }
    }

    public void SetModule(Module module)
    {
        this.module = module;

        if (progressBar == null)
        {
            progressBar = GetComponent<Image>();
        }
        else {
            Debug.Log("Progress bar is not null");
        }
            progressBar.fillAmount = module.GetProgress() / 100f;
            progressText.text = $"{progressBar.fillAmount * 100:F0}%";
            moduleSideText.text = module.moduleName; 
    }

    private void UpdateModuleProgress()
    {
        if (module != null && !module.IsCompleted())
        {
            float productivity = Student.Instance.GetProductivityOfModule(module.moduleType);
            module.AddToProgress(Time.deltaTime / (module.moduleDifficulty / 10) * productivity);
            progressBar.fillAmount = module.GetProgress() / 100f;
            progressText.text = $"{progressBar.fillAmount * 100:F0}%";
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
        if (progressBar == null || progressText == null || moduleSideText == null)
        {
            Debug.LogWarning("One or more components are null. Cannot reset progress.");
            return;
        }
        progressBar.fillAmount = 0;
        progressText.text = "0%";
        module.ResetProgress();
    }
    public void SaveProgress()
    {
        if (module != null)
        {
            module.AddToProgress(progressBar.fillAmount * 100 - module.GetProgress());
        }
    }

    public Boolean IsUpdating()
    {
        return isUpdating;
    }

    public float GetProgressFillAmount()
    {
        return progressBar.fillAmount;
    }
}
