using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateCharacterScript : MonoBehaviour
{

    public Student PLAYER; 
    [SerializeField] GameObject panelIntro;
    [SerializeField] GameObject panelGetName;
    [SerializeField] GameObject panelGetCourse;
    public TMP_InputField inputField;
    private string playerName;
    private string facultyChosen;

    private void Awake()
    {
        PLAYER = Student.Instance; 
        panelIntro.SetActive(true);
        panelGetName.SetActive(false);
        panelGetCourse.SetActive(false);
    }
    public void OnStartQuiz()
    {
        panelIntro.SetActive(false);
        panelGetName.SetActive(true);
    }

    public void OnNameSubmit()
    {
        playerName = inputField.text;
        PLAYER.SetName(playerName); 
        panelGetName.SetActive(false);
        panelGetCourse.SetActive(true);
    }

    public void OnCourseSubmit()
    {
        facultyChosen = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        switch(facultyChosen) {
            case "SOC":
                PLAYER.SetFaculty("SOC");
                Debug.Log("Faculty 1 chosen");
                break;
            case "FOS":
                PLAYER.SetFaculty("FOS");
                Debug.Log("Faculty 2 chosen");
                break;
            case "FASS":
                PLAYER.SetFaculty("FASS");
                Debug.Log("Faculty 3 chosen");
                break;
            case "CDE":
                PLAYER.SetFaculty("CDE");
                Debug.Log("Faculty 4 chosen");
                break;
            case "BIZ":
                PLAYER.SetFaculty("BIZ");
                Debug.Log("Faculty 5 chosen");
                break;
            default: 
                Debug.Log("No faculty chosen");
                break;
        }
    }

    public void OnCourseNextButton()
    {
        SceneManager.LoadScene("SelectSemester");
    }
}