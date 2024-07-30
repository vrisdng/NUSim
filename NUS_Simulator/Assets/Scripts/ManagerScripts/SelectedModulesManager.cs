using System.Collections.Generic;
using UnityEngine;

public class SelectedModulesManager : MonoBehaviour
{
    public static SelectedModulesManager Instance { get; private set; }
    
    public Module[] SelectedModules { get; private set; } = new Module[5];

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

    public void SetSelectedModules(Module[] modules)
    {
        SelectedModules = modules;
    }

    public Module[] GetSelectedModules()
    {
        return SelectedModules;
    }

    public void ResetSelectedModules()
    {
        SelectedModules = new Module[5];
        Debug.Log("Selected modules have been reset for the new semester.");
    }

    public void ResetAllProgress()
    {
        foreach (Module module in SelectedModules)
        {
            if (module != null)
            {
                module.ResetProgress();
            }
        }
    }

    public void CompleteModulesOfCurrentSemester()
    {
        foreach (Module module in SelectedModules)
        {
            if (module == null)
            {
                continue;
            }
            Debug.Log(module.moduleName);
            module.SetCompleted(true);
        }
    }
}
