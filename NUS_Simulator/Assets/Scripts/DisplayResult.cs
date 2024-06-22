using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
/*
public class DisplayResult : MonoBehaviour
{
    public GameObject button; 
    [SerializeField] TextMeshProUGUI gradesReport;
    [SerializeField] TextMeshProUGUI mentalPoints;
    [SerializeField] TextMeshProUGUI physicalPoints;
    [SerializeField] TextMeshProUGUI socialPoints;

    [SerializeField] TextMeshProUGUI finalReport;
    [SerializeField] TextMeshProUGUI congrats;
    [SerializeField] ModuleData moduleData; 

    private Student PLAYER = Student.Instance; 

    public void Start()
    {
        Debug.Log("?"); 
    }
    public void OnClick()
    {
        Debug.Log("Displaying results...");
        DisplayResults(); 
        button.SetActive(false);
    }

    string RandomGradeGenerator(float progress)
    {
        Dictionary<string, float> gradeProbabilities = new Dictionary<string, float>();

        if (progress >= 0 && progress <= 20)
        {
            gradeProbabilities = new Dictionary<string, float>
            {
                { "D", 0.50f },
                { "F", 0.50f }
            };
        }
        else if (progress >= 20 && progress < 45)
        {
            gradeProbabilities = new Dictionary<string, float>
            {
                { "C", 0.50f },
                { "D", 0.50f }
            };
        }
        else if (progress >= 45 && progress < 75)
        {
            gradeProbabilities = new Dictionary<string, float>
            {
                { "A", 0.10f },
                { "B", 0.70f },
                { "C", 0.20f }
            };
        }
        else if (progress >= 75)
        {
            gradeProbabilities = new Dictionary<string, float>
            {
                { "A", 0.80f },
                { "B", 0.20f }
            };
        }

        float randomValue = UnityEngine.Random.value;
        float cumulativeProbability = 0f;

        foreach (var gradeProbability in gradeProbabilities)
        {
            cumulativeProbability += gradeProbability.Value;
            if (randomValue <= cumulativeProbability)
            {
                return gradeProbability.Key;
            }
        }

        return "F"; // Default to "F" if no grade is selected
    }

    float GradeToScore(string grade)
    {
        switch (grade)
        {
            case "A":
                return 5.0f;
            case "B":
                return 3.5f;
            case "C":
                return 2.0f;
            case "D":
                return 1.0f;
            case "F":
                return 0.0f;
            default:
                return 0.0f;
        }
    }

    float CalculateAverageGrade(List<string> grades)
    {
        float totalScore = 0f;
        foreach (string grade in grades)
        {
            totalScore += GradeToScore(grade);
        }
        return totalScore / grades.Count;
    }

    void DisplayResults()
    {
        Module[] modules = moduleData.GetAllModules();
        ModuleProgressValue[] progressValues = moduleData.GetAllModulesProgress();

        string gradesText = "Grades:\n";
        List<string> grades = new List<string>();

        for (int i = 0; i < modules.Length; i++)
        {
            float progress = progressValues[i].GetProgressPercentage() * 100;
            string grade = RandomGradeGenerator(progress);
            grades.Add(grade);
            gradesText += $"{modules[i].GetModuleName()}: {grade}\n";
        }

        float averageGrade = CalculateAverageGrade(grades);
        PLAYER.SetGPA(averageGrade); 
        gradesText += $"Average Grade: {averageGrade:F2}\n";

        gradesReport.text = gradesText;

        mentalPoints.text = "Mental Points: " + Mathf.RoundToInt(Student.Instance.GetMentalPoints());
        physicalPoints.text = "Physical Points: " + Mathf.RoundToInt(Student.Instance.GetPhysicalPoints());
        socialPoints.text = "Social Points: " + Mathf.RoundToInt(Student.Instance.GetSocialPoints());

        float totalPoints = Mathf.RoundToInt(Student.Instance.GetMentalPoints() + Student.Instance.GetPhysicalPoints() + Student.Instance.GetSocialPoints());
        float finalScore = averageGrade * 10 + totalPoints;

        finalReport.text = "Your final score is: " + finalScore;

        if (finalScore > 90)
        {
            congrats.text = " Congratulations! You are the academic weapon!";
        }
        else if (finalScore > 70)
        {
            congrats.text = " Not bad! Keep it up!";
        }
        else if (finalScore > 50)
        {
            congrats.text = " You passed. Yay! Survived NUS!";
        }
        else
        {
            congrats.text = " You need to work harder!";
        }
    }
}
*/