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

    private void DisplayResults()
    {
        var modules = SelectedModulesManager.Instance.GetSelectedModules();
        var grades = GenerateGrades(modules);
        var averageGrade = Grade.CalculateAverageGrade(grades);
        PLAYER.SetGPA(averageGrade);

        DisplayGrades(grades, averageGrade);
        DisplayPoints();
        DisplayFinalReport(averageGrade);
    }

    private void SetPlayerGPA(float averageGrade)
    {
        PLAYER.SetGPA(averageGrade);
    }   

    private List<string> GenerateGrades(Module[] modules)
    {
        List<string> grades = new List<string>();
        foreach (var module in modules)
        {
            float progress = module.GetProgress();
            Debug.Log("The progress of this module " + module + " is " + progress);
            string grade = Grade.RandomGradeGenerator(progress);
            grades.Add(grade);
        }
        return grades;
    }

    private void DisplayGrades(List<string> grades, float averageGrade)
    {
        string gradesText = "Grades:\n";
        for (int i = 0; i < grades.Count; i++)
        {
            gradesText += $"{SelectedModulesManager.Instance.GetSelectedModules()[i].GetModuleName()}: {grades[i]}\n";
        }
        gradesText += $"Average Grade: {averageGrade:F2}\n";
        gradesReport.text = gradesText;
    }

    private void DisplayPoints()
    {
        mentalPoints.text = "Mental Points: " + Mathf.RoundToInt(Student.Instance.GetMentalPoints());
        physicalPoints.text = "Physical Points: " + Mathf.RoundToInt(Student.Instance.GetPhysicalPoints());
        socialPoints.text = "Social Points: " + Mathf.RoundToInt(Student.Instance.GetSocialPoints());
    }

    private void DisplayFinalReport(float averageGrade)
    {
        if (GAMEMODE.GetGameMode() == GameMode.Kiasu)
        {
            DisplayKiasuModeReport(averageGrade);
            return;
        }

        if (GAMEMODE.GetGameMode() == GameMode.Linear)
        {
            DisplayLinearModeReport(averageGrade);
        }
    }

    private void DisplayKiasuModeReport(float averageGrade)
    {
        if (averageGrade >= 5.0f)
        {
            SetFinalReport("Congratulations! You have become the Ultimate Kiasu!", true, false);
            return;
        }

        if (HasAnyPoints(50))
        {
            SetFinalReport("You have failed to become Kiasu!", false, true, "However, thanks to social merits, you have unlocked an item to aid you in the next round!");
            return;
        }

        SetFinalReport("You have totally failed to become anything, let alone Kiasu!", true, false, "Better luck next time!");
    }

    private void DisplayLinearModeReport(float averageGrade)
    {
        if (averageGrade >= 3.0f && HasAnyPoints(0))
        {
            SetFinalReport("Congratulations! Your grades have passed the semester!", false, true, "You have unlocked the next semester and earn rewards!");
            SELECTED_MODULES.CompleteModulesOfCurrentSemester();
            return;
        }

        SetFinalReport("You have failed the semester.", true, false, "You have not unlocked the next semester. Better luck next time!");
    }

    private void SetFinalReport(string finalText, bool showStartOver, bool showRewards, string congratsText = "")
    {
        Utils.SetText(finalReport, finalText);
        startOverButton.SetActive(showStartOver);
        getRewardsButton.SetActive(showRewards);
        if (!string.IsNullOrEmpty(congratsText))
        {
            Utils.SetText(congrats, congratsText);
        }
    }

    private bool HasAnyPoints(int points)
    {
        var student = Student.Instance;
        return student.GetMentalPoints() == points || student.GetPhysicalPoints() == points || student.GetSocialPoints() == points;
    }
}