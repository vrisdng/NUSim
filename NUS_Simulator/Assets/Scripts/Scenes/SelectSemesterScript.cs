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
        ShowStatusOfAllSemesters(); 
    }

    private void UpdateSemesterButtons()
    {
        Semester[] semesters = SemesterManager.Instance.GetAvailableSemesters();

        for (int i = 0; i < semesterButtons.Length; i++)
        {
            if (i == SemesterManager.Instance.GetCurrentSemesterIndex())
            {
                Debug.Log("Index of curr semester" + i); 
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
            SceneManager.LoadScene("Select Modules");
        }
    }

    public void ShowStatusOfAllSemesters()
    {
        Semester[] semesters = SemesterManager.Instance.GetAvailableSemesters();
        string text = "";
        for (int i = 0; i < semesters.Length; i++)
        {
            text += semesters[i].GetName() + ": " + (semesters[i].IsCompleted() ? "Completed" : "Not Completed") + "\n";
        }
        Debug.Log(text);
    }
}
