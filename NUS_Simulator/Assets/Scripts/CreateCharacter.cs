using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateCharacter : MonoBehaviour
{

    [SerializeField] GameObject panelIntro;
    [SerializeField] GameObject panelGetName;
    [SerializeField] GameObject panelGetCourse;
    public TMP_InputField inputField;
    private string playerName;
    private string facultyChosen;

    private void Awake()
    {
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
        panelGetName.SetActive(false);
        panelGetCourse.SetActive(true);
    }

    public void OnCourseSubmit()
    {
        facultyChosen = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        switch(facultyChosen) {
            case "SOC":
                Debug.Log("Faculty 1 chosen");
                break;
            case "FOS":
                Debug.Log("Faculty 2 chosen");
                break;
            case "FASS":
                Debug.Log("Faculty 3 chosen");
                break;
            case "CDE":
                Debug.Log("Faculty 4 chosen");
                break;
            case "BIZ":
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