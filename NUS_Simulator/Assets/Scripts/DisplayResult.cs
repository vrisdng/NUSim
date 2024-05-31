using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DisplayResult : MonoBehaviour
{
    public GameObject button; 
    [SerializeField] TextMeshProUGUI gradesReport;
    [SerializeField] TextMeshProUGUI mentalPoints;
    [SerializeField] TextMeshProUGUI physicalPoints;
    [SerializeField] TextMeshProUGUI socialPoints;

    [SerializeField] TextMeshProUGUI finalReport;
    [SerializeField] TextMeshProUGUI congrats;
    public void OnClick()
    {
        DisplayResults(); 
        button.SetActive(false);
    }

    string RandomGradeGenerator() {
        string[] grades = { "A", "B", "C", "D" };  
        System.Random random = new System.Random();
        int index = random.Next(grades.Length);
        
        return grades[index];
    }

    void DisplayResults() {
        string grade = RandomGradeGenerator();
        gradesReport.text = "Your grade is: " + grade;

        mentalPoints.text = "Mental Points: " + Mathf.RoundToInt(Student.Instance.GetMentalPoints());
        physicalPoints.text = "Physical Points: " + Mathf.RoundToInt(Student.Instance.GetPhysicalPoints());
        socialPoints.text = "Social Points: " + Mathf.RoundToInt(Student.Instance.GetSocialPoints());

        float totalPoints = Mathf.RoundToInt(Student.Instance.GetMentalPoints() + Student.Instance.GetPhysicalPoints() + Student.Instance.GetSocialPoints());
        int gradeToScore = grade == "A" ? 4 : grade == "B" ? 3 : grade == "C" ? 2 : 1;
        float finalScore = gradeToScore * 10 + totalPoints; 
        
        finalReport.text = "Your final score is: " + finalScore;

        if (finalScore > 90) {
            congrats.text = " Congratulations! You are the academic weapon!";
        } else if (finalScore > 70) {
            congrats.text = " Not bad! Keep it up!";
        } else if (finalScore > 50) {
            congrats.text = " You passed. Yay! Survived NUS!";
        } else {
            congrats.text = " You need to work harder!";
        }
    }
}
