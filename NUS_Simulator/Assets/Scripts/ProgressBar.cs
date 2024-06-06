using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using TMPro;

public class ProgressBar : MonoBehaviour {
    private Image progressBar;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private TextMeshProUGUI moduleSideText;
    private ModuleProgressValue moduleProgressValue;
    private bool isUpdating;

    void Start() {
        // Attempt to get the Image component
        progressBar = GetComponent<Image>();
        if (progressBar != null) {
            progressBar.fillAmount = 0.0f;
            progressText.text = "0%"; 
        }
        isUpdating = false;
    }

    void Update() {
    }

    public void SetModuleSideText(string text) {
        moduleSideText.text = text;
    }

    public void SetModuleProgress(ModuleProgressValue progress) {
        moduleProgressValue = progress;
        if (moduleProgressValue != null) {
            if (progressBar == null) {
                progressBar = GetComponent<Image>();
            }
            progressBar.fillAmount = moduleProgressValue.GetProgress() / moduleProgressValue.GetMaxTime();
            progressText.text = (progressBar.fillAmount * 100).ToString("F0") + "%";
        }
    }

    public void UpdateModuleProgress(float speed) {
        if (moduleProgressValue != null && moduleProgressValue.GetProgress() < moduleProgressValue.GetMaxTime()) {
            moduleProgressValue.SetProgress(moduleProgressValue.GetProgress() + Time.deltaTime * speed);
            progressBar.fillAmount = moduleProgressValue.GetProgress() / moduleProgressValue.GetMaxTime();
            progressText.text = (progressBar.fillAmount * 100).ToString("F0") + "%";
            Debug.Log("Updated progress: " + moduleProgressValue.GetProgress() + "/" + moduleProgressValue.GetMaxTime());
        } else if (moduleProgressValue.GetProgress() >= moduleProgressValue.GetMaxTime()) {
            Debug.Log("Updated progress: " + moduleProgressValue.GetProgress() + "/" + moduleProgressValue.GetMaxTime());
            Debug.Log("Module completed");
        }
    }

    public void StartProgress() {
        Debug.Log("Starting progress");
        isUpdating = true;
    }

    public void StopProgress() {
        Debug.Log("Stop progress");
        isUpdating = false;
    }

    public void ResetProgress() {
        if (moduleProgressValue != null) {
            moduleProgressValue.ResetProgress();
            progressBar.fillAmount = 0;
            progressText.text = "0%";
        }
    }

    public void CloseWorkPanel() {
        SceneManager.LoadScene("InGameScreen");
    }
}

