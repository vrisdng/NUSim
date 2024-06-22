using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*public class SelectSemesterScript : MonoBehaviour {
    // Assuming you have references to your semester buttons in the inspector
    public Button year1Semester1Button;
    public Button year1Semester2Button;
    public Button year2Semester1Button;
    // Add more buttons as needed for other semesters

    private void Start() {
        // Assign onClick listeners to each button
        year1Semester1Button.onClick.AddListener(() => SelectSemester("Year 1 Semester 1"));
        year1Semester2Button.onClick.AddListener(() => SelectSemester("Year 1 Semester 2"));
        year2Semester1Button.onClick.AddListener(() => SelectSemester("Year 2 Semester 1"));
        // Add listeners for other semesters' buttons
    }

    private void SelectSemester(string semesterName) {
        // Determine which semester was selected and load corresponding modules scene
        switch (semesterName) {
            case "Year 1 Semester 1":
                LoadModulesScene(0); // Assuming index 0 corresponds to Year 1 Semester 1 in ModuleData
                break;
            case "Year 1 Semester 2":
                LoadModulesScene(1); // Assuming index 1 corresponds to Year 1 Semester 2 in ModuleData
                break;
            case "Year 2 Semester 1":
                LoadModulesScene(2); // Assuming index 2 corresponds to Year 2 Semester 1 in ModuleData
                break;
            // Add cases for other semesters as needed
            default:
                Debug.LogError("Unknown semester selected: " + semesterName);
                break;
        }
    }

    private void LoadModulesScene(int semesterIndex) {
        // Set the selected semester index in ModuleData
        ModuleData.SetSelectedSemesterIndex(semesterIndex);

        // Load the scene where modules are selected
        SceneManager.LoadScene("SelectModulesScene");
    }
}
*/