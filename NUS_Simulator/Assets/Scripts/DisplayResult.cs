using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class DisplayResult : MonoBehaviour
{
    public GameObject displayButton; 
    public GameObject startOverButton;
    public GameObject getRewardsButton; 
    [SerializeField] TextMeshProUGUI gradesReport;
    [SerializeField] TextMeshProUGUI mentalPoints;
    [SerializeField] TextMeshProUGUI physicalPoints;
    [SerializeField] TextMeshProUGUI socialPoints;

    [SerializeField] TextMeshProUGUI finalReport;
    [SerializeField] TextMeshProUGUI congrats;

    private Student PLAYER = Student.Instance; 
    private GameModeManager GAMEMODE = GameModeManager.Instance;
    private SemesterManager SEMESTER = SemesterManager.Instance;
    private SelectedModulesManager SELECTED_MODULES = SelectedModulesManager.Instance;

    public void Start()
    {
        Debug.Log("?"); 
        startOverButton.SetActive(false);
        getRewardsButton.SetActive(false);
    }
    public void OnClick()
    {
        Debug.Log("Displaying results...");
        DisplayResults(); 
        displayButton.SetActive(false);
    }

    string RandomGradeGenerator(float progress)
    {
        Dictionary<string, float> gradeProbabilities = new Dictionary<string, float>();

        if (progress >= 0 && progress <= 20)
        {
            gradeProbabilities = new Dictionary<string, float>
            {
                { "D", 0.20f },
                { "F", 0.80f }
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

        return "F"; 
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
        Module[] modules = SelectedModulesManager.Instance.GetSelectedModules();

        string gradesText = "Grades:\n";
        List<string> grades = new List<string>();

        for (int i = 0; i < modules.Length; i++)
        {
            float progress = modules[i].GetProgress(); 
            Debug.Log("The progress of this module " + modules[i] + "is " + progress);
            string grade = RandomGradeGenerator(progress);
            grades.Add(grade);
            gradesText += $"{modules[i].GetModuleName()}: {grade}\n";
        }

        //float averageGrade = CalculateAverageGrade(grades);
        float averageGrade = 5.0f;
        PLAYER.SetGPA(averageGrade); 
        gradesText += $"Average Grade: {averageGrade:F2}\n";

        gradesReport.text = gradesText;

        mentalPoints.text = "Mental Points: " + Mathf.RoundToInt(Student.Instance.GetMentalPoints());
        physicalPoints.text = "Physical Points: " + Mathf.RoundToInt(Student.Instance.GetPhysicalPoints());
        socialPoints.text = "Social Points: " + Mathf.RoundToInt(Student.Instance.GetSocialPoints());

        float totalPoints = Mathf.RoundToInt(Student.Instance.GetMentalPoints() + Student.Instance.GetPhysicalPoints() + Student.Instance.GetSocialPoints());

        if (GAMEMODE.GetGameMode() == GameMode.Kiasu)
        {
            if (averageGrade >= 5.0f)
            {
                finalReport.text = "Congratulations! You have become the Ultimate Kiasu!";
                startOverButton.SetActive(true);
            }
            else {
                if (Student.Instance.GetMentalPoints() == 50 || Student.Instance.GetPhysicalPoints() == 50 || Student.Instance.GetSocialPoints() == 50)
                {
                    finalReport.text = "You have failed to become Kiasu!";
                    congrats.text = "However, thanks to social merits, you have unlocked an item to aid you in the next round!";
                    getRewardsButton.SetActive(true);
                }
                else
                {
                    finalReport.text = "You have totally failed to become anything, let alone Kiasu!";
                    congrats.text = "Better luck next time!";
                    startOverButton.SetActive(true);
                }
            }
        } else if (GAMEMODE.GetGameMode() == GameMode.Linear)
        {
            if (averageGrade >= 3.0f && (Student.Instance.GetMentalPoints() > 0 || Student.Instance.GetPhysicalPoints() > 0 || Student.Instance.GetSocialPoints() > 0))
            {
                finalReport.text = "Congratulations! Your grades have passed the semester!";
                congrats.text = "You have unlocked the next semester and earn rewards!";
                getRewardsButton.SetActive(true);
                //SEMESTER.CompleteCurrentSemester();
                SELECTED_MODULES.CompleteModulesOfCurrentSemester(); 
                
                
            }
            else if (averageGrade < 3.0f)
            {
                finalReport.text = "You have failed the semester.";
                congrats.text = "You have not unlocked the next semester.";
                startOverButton.SetActive(true);
            }
            else 
            { 
                startOverButton.SetActive(true);
                finalReport.text = "You have failed the semester.";
                congrats.text = "Better luck next time!";
                startOverButton.SetActive(true);
            }
        }
    }
}
