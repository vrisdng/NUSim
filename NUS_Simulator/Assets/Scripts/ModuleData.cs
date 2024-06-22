using UnityEngine;
/*
[CreateAssetMenu(fileName = "ModuleData", menuName = "ScriptableObjects/ModuleData", order = 1)]
public class ModuleData : ScriptableObject {
    public Module[] modules = new Module[5];
    public ModuleProgressValue[] moduleProgressValues = new ModuleProgressValue[5];

    public Semester[] semesters;
    private static int selectedSemesterIndex = -1;
    private void OnEnable() {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
        InitializeSemesters();   // Initialize semesters in OnEnable
    }

        private void InitializeSemesters() {
        semesters = new Semester[] {
            new Semester("Year 1 Semester 1", new Module[] {
                new Module("CS1101S", 5, 1f),
                new Module("CS1231S", 5, 1f),          
                new Module("MA1521", 5, 0.8f),
                new Module("MA1522", 5, 0.8f),
                new Module("GEA1000", 5, 0.8f),
                new Module("CS2030S", 5, 0.8f),
                new Module("CS2040", 5, 0.8f),
                new Module("CS2040S", 5, 0.8f),
                // Add more modules as needed
            }),
            new Semester("Year 1 Semester 2", new Module[] {
                new Module("CS2040", 5, 0.8f),
                new Module("CS2040S", 5, 0.8f),
                new Module("CS1010", 5, 1f),
                new Module("MA1521", 5, 0.8f),
                new Module("MA1522", 5, 0.8f),
                new Module("GEA1000", 5, 0.8f),
            }),
        };
    }

    public Semester GetSemester(int index) {
        if (index >= 0 && index < semesters.Length) {
            return semesters[index];
        }
        return null;
    }

    public Module GetModule(int semesterIndex, int moduleIndex) {
        if (semesterIndex >= 0 && semesterIndex < semesters.Length) {
            return semesters[semesterIndex].availableModules[moduleIndex];
        }
        return null;
    }

    public void SelectModule(int semesterIndex, int moduleIndex, int selectionIndex) {
        if (semesterIndex >= 0 && semesterIndex < semesters.Length &&
            selectionIndex >= 0 && selectionIndex < 5) {
            semesters[semesterIndex].selectedModules[selectionIndex] = semesters[semesterIndex].availableModules[moduleIndex];
        }
    }

    public Module[] GetSelectedModules(int semesterIndex) {
        if (semesterIndex >= 0 && semesterIndex < semesters.Length) {
            return semesters[semesterIndex].selectedModules;
        }
        return null;
    }

    public static int GetSelectedSemesterIndex() {
        return selectedSemesterIndex;
    }

    public static void SetSelectedSemesterIndex(int index) {
        selectedSemesterIndex = index;
    }

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
*/