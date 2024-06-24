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
                Debug.Log(PLAYER.GetFaculty());
                break;
            case "FOS":
                PLAYER.SetFaculty("FOS");
                Debug.Log(PLAYER.GetFaculty());
                break;
            case "FASS":
                PLAYER.SetFaculty("FASS");
                Debug.Log(PLAYER.GetFaculty());
                break;
            case "CDE":
                PLAYER.SetFaculty("CDE");
                Debug.Log(PLAYER.GetFaculty());
                break;
            case "BIZ":
                PLAYER.SetFaculty("BIZ");
                Debug.Log(PLAYER.GetFaculty());
                break;
            default: 
                Debug.Log(PLAYER.GetFaculty());
                break;
        }
    }

    public void OnCourseNextButton()
    {
        if (GameModeManager.Instance.GetGameMode() == GameMode.Linear)
        {
            SceneManager.LoadScene("SelectSemester");
        }
        else if (GameModeManager.Instance.GetGameMode() == GameMode.Kiasu)
        {
            SceneManager.LoadScene("Select Modules");
        }
    }
}