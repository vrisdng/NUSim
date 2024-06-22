using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class SemesterManager : MonoBehaviour
{
    public Button y1s1;
    public Button y1s2;

    public Button y2s1;
    public Button y2s2;
    public Button y3s1;
    public Button y3s2;
    public Button y4s1;
    public Button y4s2;

    public void OnClickSemester()
    {
        Button clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        // List<Module> chosenModules = new List<Module>(); 
        switch (clickedButton.name) {
            case "y1s1":
                Semester year1sem1 = new Semester("year1sem1");
                break;
            case "y1s2":
                Semester year1sem2 = new Semester("year1sem2");
                SceneManager.LoadScene("Select Modules");
                break;
            case "y2s1":
                Semester year2sem1 = new Semester("year2sem1");
                break;
            case "y2s2":
                Semester year2sem2 = new Semester("year2sem2");
                break;
            case "y3s1":
                Semester year3sem1 = new Semester("year3sem1");
                break;
            case "y3s2":
                Semester year3sem2 = new Semester("year3sem2");
                break;
            case "y4s1":
                Semester year4sem1 = new Semester("year4sem1");
                break;
        }
        SceneManager.LoadScene("Select Modules");
    }
}