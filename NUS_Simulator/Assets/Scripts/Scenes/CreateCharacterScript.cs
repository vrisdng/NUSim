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
    public static string facultyChosen;

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
        PLAYER.InitializeProductivity(); 
        panelGetName.SetActive(false);
        panelGetCourse.SetActive(true);
    }

    public void OnCourseSubmit()
    {
        facultyChosen = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        switch(facultyChosen) {
            case "SOC":
                PLAYER.SetFaculty("Computing");
                facultyChosen = "Computing";
                Debug.Log(PLAYER.GetFaculty());
                break;
            case "FOS":
                PLAYER.SetFaculty("Science");
                facultyChosen = "Science";
                Debug.Log(PLAYER.GetFaculty());
                break;
            case "FASS":
                PLAYER.SetFaculty("Arts and Social Science");
                facultyChosen = "Arts and Social Science";
                Debug.Log(PLAYER.GetFaculty());
                break;
            case "CDE":
                PLAYER.SetFaculty("College of Design and Engineering");
                facultyChosen = "College of Design and Engineering";
                Debug.Log(PLAYER.GetFaculty());
                break;
            case "BIZ":
                PLAYER.SetFaculty("NUS Business School");
                facultyChosen = "NUS Business School";
                Debug.Log(PLAYER.GetFaculty());
                break;
            default: 
                break;
        }
        
        if (Student.Instance.GetGameMode() == GameMode.Linear) {
            SceneManager.LoadScene("SelectSemester");
        } else {
            SceneManager.LoadScene("Select Modules");
        }
    }

    public void OnCourseNextButton()
    {
        if (Student.Instance.GetGameMode() == GameMode.Linear)
        {
            SceneManager.LoadScene("SelectSemester");
        }
        else if (Student.Instance.GetGameMode() == GameMode.Kiasu)
        {
            SceneManager.LoadScene("Select Modules");
        }
    }
}