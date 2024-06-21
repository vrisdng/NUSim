using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class StudyManager : MonoBehaviour
{
    public static StudyManager Instance { get; private set; }

    [SerializeField] private ModuleData moduleData; // Reference to the ModuleData ScriptableObject
    private Dictionary<int, ModuleProgressValue> moduleProgressDictionary = new Dictionary<int, ModuleProgressValue>();
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
    }

    private void Start()
    {
        InitializeModuleProgress();
    }

    public void SetProgressBars(ProgressBar[] bars)
    {
        progressBars = bars;
    }

    private void InitializeModuleProgress()
    {
        for (int i = 0; i < moduleData.GetAllModules().Length; i++)
        {
            ModuleProgressValue moduleProgress = moduleData.GetModuleProgress(i);
            if (moduleProgress == null)
            {
                moduleProgress = new ModuleProgressValue(25.0f); // Example maxTime value
                moduleData.moduleProgressValues[i] = moduleProgress;
                Debug.Log("Module Progress initialized for module " + i + " with progress: " + moduleProgress.GetProgressPercentage());
                Debug.Log("Name of the module is: " + moduleData.GetModule(i).GetModuleName());
            }
            moduleProgressDictionary[i] = moduleProgress;
        }
    }

    public void StartStudying(int moduleIndex)
    {
        if (activeModuleIndex != -1)
        {
            StopStudying();
        }

        activeModuleIndex = moduleIndex;
        isStudying = true; 

        Module activeModule = moduleData.GetModule(activeModuleIndex);
        activeModule.isStudying = true;

        // Logic to start progress update
        ProgressBar progressBar = GetProgressBarForModule(activeModuleIndex);
        if (progressBar != null)
        {
            progressBar.StartProgress();
        }
    }

    public void StopStudying()
    {
        if (activeModuleIndex != -1)
        {
            isStudying = false;

            Module activeModule = moduleData.GetModule(activeModuleIndex);
            activeModule.isStudying = false;

            // Logic to stop progress update
            ProgressBar progressBar = GetProgressBarForModule(activeModuleIndex);
            if (progressBar != null)
            {
                progressBar.StopProgress();
            }
        }
    }

    public void SwitchModule(int newModuleIndex)
    {
        activeModuleIndex = newModuleIndex;
    }

    public int GetActiveModuleIndex()
    {
        return activeModuleIndex;
    }

    public ModuleProgressValue GetModuleProgress(int moduleIndex)
    {
        if (moduleProgressDictionary.TryGetValue(moduleIndex, out ModuleProgressValue moduleProgress))
        {
            return moduleProgress;
        }
        return null;
    }

    private ProgressBar GetProgressBarForModule(int moduleIndex)
    {
        // Access the ProgressBar from the array using the moduleIndex
        if (moduleIndex >= 0 && moduleIndex < progressBars.Length)
        {
            return progressBars[moduleIndex];
        }
        return null;
    }

    public bool IsStudying() 
    {
        return isStudying;
    }

    public void ResetAllProgress()
    {
        for (int i = 0; i < moduleData.GetAllModules().Length; i++)
        {
            ModuleProgressValue moduleProgress = moduleData.GetModuleProgress(i);
            moduleProgress.SetProgress(0.0f);
        }
    }

    public float GetAllProgress()
    {
        float totalProgress = 0.0f;
        for (int i = 0; i < moduleData.GetAllModules().Length; i++)
        {
            ModuleProgressValue moduleProgress = moduleData.GetModuleProgress(i);
            totalProgress += moduleProgress.GetProgressPercentage();
        }
        return totalProgress;
    }
}
