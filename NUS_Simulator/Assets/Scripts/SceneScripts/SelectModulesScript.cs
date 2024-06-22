using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using System;

// For ModuleSelectScene
public class SelectModulesScript : MonoBehaviour {
    private int clickedCount = 0;
    
    [SerializeField] public ModuleData moduleData;        // Reference to the ModuleData ScriptableObject

    void Start() {
        // Retrieve the selected semester index from ModuleData
        int selectedSemesterIndex = ModuleData.GetSelectedSemesterIndex();

        // Display modules for the selected semester
        DisplayModules(selectedSemesterIndex);
    }
    

    public void ClickOnModule() {
        if (clickedCount < 5) {
            Button clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
            string clickedButtonModuleName = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;
            clickedButton.interactable = false;

            Module selectedModule = FindModuleByName(clickedButtonModuleName);
            if (selectedModule != null) {
                moduleData.SelectModule(ModuleData.GetSelectedSemesterIndex(), Array.IndexOf(moduleData.GetSemester(ModuleData.GetSelectedSemesterIndex()).availableModules, selectedModule), clickedCount);
                Debug.Log("Module " + selectedModule.GetModuleName() + " selected for " + moduleData.GetSemester(ModuleData.GetSelectedSemesterIndex()).name);
                clickedCount++;
            }
        } else {
            Debug.Log("Maximum of 5 modules have already been selected for " + moduleData.GetSemester(ModuleData.GetSelectedSemesterIndex()).name);
            // TODO: Proceed to the next semester or scene
        }
    }

    private Module FindModuleByName(string moduleName) {
        int selectedSemesterIndex = ModuleData.GetSelectedSemesterIndex();
        if (selectedSemesterIndex != -1) {
            foreach (Module module in moduleData.GetSemester(selectedSemesterIndex).availableModules) {
                if (module.GetModuleName() == moduleName) {
                    return module;
                }
            }
            Debug.Log("Module not found: " + moduleName);
        } else {
            Debug.LogError("No semester selected.");
        }
        return null;
    }

    private void DisplayModules(int semesterIndex) {
        if (semesterIndex != -1) {
            Semester selectedSemester = moduleData.GetSemester(semesterIndex);
            if (selectedSemester != null) {
                foreach (Module module in selectedSemester.availableModules) {
                if (module != null) {
                        Debug.Log("Displaying module: " + module.GetModuleName());
                }}
            } else {
                Debug.LogError("Selected semester is null.");
            }
        } else {
            Debug.LogError("No semester selected.");
        }
    }
}
