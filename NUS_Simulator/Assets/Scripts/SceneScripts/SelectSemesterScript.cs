using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class SelectSemesterScript : MonoBehaviour
{
    public Button[] semesterButtons;

    void Start()
    {
        UpdateSemesterButtons();
    }

    private void UpdateSemesterButtons()
    {
        Semester[] semesters = SemesterManager.Instance.GetAvailableSemesters();

        for (int i = 0; i < semesterButtons.Length; i++)
        {
            if (i == SemesterManager.Instance.GetCurrentSemesterIndex())
            {
                semesterButtons[i].interactable = true;
            }
            else
            {
                semesterButtons[i].interactable = false;
            }

        }
    }

    public void OnClickSemester()
    {
        Button clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        string buttonName = clickedButton.name;

        int semesterIndex = System.Array.FindIndex(semesterButtons, button => button.name == buttonName);

        if (semesterIndex != -1)
        {
            SemesterManager.Instance.CompleteCurrentSemester();
            UpdateSemesterButtons();
            SceneManager.LoadSceneAsync("Select Modules");
        }
    }
}
