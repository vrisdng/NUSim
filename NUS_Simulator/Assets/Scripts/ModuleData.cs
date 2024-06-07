using UnityEngine;

[CreateAssetMenu(fileName = "ModuleData", menuName = "ScriptableObjects/ModuleData", order = 1)]
public class ModuleData : ScriptableObject {
    public Module[] modules = new Module[5];
    public ModuleProgressValue[] moduleProgressValues = new ModuleProgressValue[5];

    public void SetModule(int index, Module module) {
        if (index >= 0 && index < modules.Length) {
            modules[index] = module;
        }
    }

    public Module GetModule(int index) {
        if (index >= 0 && index < modules.Length) {
            return modules[index];
        }
        return null;
    }

    public ModuleProgressValue GetModuleProgress(int index) {
        if (index >= 0 && index < modules.Length) {
            return moduleProgressValues[index];
        }
        return null;
    }

    public ModuleProgressValue[] GetAllModulesProgress() {
        return moduleProgressValues; 
    }

    public Module[] GetAllModules() {
        return modules;
    }
}
