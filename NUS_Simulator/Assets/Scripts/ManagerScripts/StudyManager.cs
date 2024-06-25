using System.Collections.Generic;
using UnityEngine;

public class StudyManager : MonoBehaviour
{
    public static StudyManager Instance { get; private set; }

    private ProgressBar[] progressBars; 
    private int activeModuleIndex = -1;
    private bool isStudying;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetProgressBars(ProgressBar[] bars)
    {
        progressBars = bars;
    }

    public int GetActiveModuleIndex()
    {
        return activeModuleIndex;
    }

    public void StartStudying()
    {
        if (activeModuleIndex == -1) return;

        isStudying = true;
        progressBars[activeModuleIndex].StartProgress();
    }

    public void StartStudying(int moduleIndex)
    {
        if (activeModuleIndex != -1)
        {
            StopStudying();
        }

        activeModuleIndex = moduleIndex;
        isStudying = true; 

        Module activeModule = SelectedModulesManager.Instance.SelectedModules[activeModuleIndex];
        activeModule.isStudying = true;

        ProgressBar progressBar = GetProgressBarForModule(activeModuleIndex);
        if (progressBar != null)
        {
            progressBar.StartProgress();
        }
    }

    private ProgressBar GetProgressBarForModule(int moduleIndex)
    {
        if (moduleIndex >= 0 && moduleIndex < progressBars.Length)
        {
            return progressBars[moduleIndex];
        }
        return null;
    }

    public ProgressBar[] GetProgressBars()
    {
        return progressBars;
    }

    public void StopStudying()
    {
        if (activeModuleIndex == -1) return;

        isStudying = false;
        progressBars[activeModuleIndex].StopProgress();
    }

    public void StopAllStudying()
    {
        isStudying = false;
        foreach (ProgressBar progressBar in progressBars)
        {
            progressBar.StopProgress();
        }
    }

    public void SwitchModule(int newModuleIndex)
    {
        activeModuleIndex = newModuleIndex;
    }

    public bool IsStudying()
    {
        return isStudying;
    }
}
