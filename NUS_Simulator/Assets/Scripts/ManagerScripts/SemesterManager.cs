using System.Collections.Generic;
using UnityEngine;

public class SemesterManager : MonoBehaviour
{
    public static SemesterManager Instance { get; private set; }
    private static SelectedModulesManager selectedModulesManager = SelectedModulesManager.Instance;

    public Semester[] semesters;
    private int currentSemesterIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeSemesters();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeSemesters()
    {
        semesters = new Semester[]
        {
            new Semester("Year 1 Semester 1"),
            new Semester("Year 1 Semester 2"),
            new Semester("Year 2 Semester 1"),
            new Semester("Year 2 Semester 2"),
            new Semester("Year 3 Semester 1"),
            new Semester("Year 3 Semester 2"),
            new Semester("Year 4 Semester 1"), 
            new Semester("Year 4 Semester 2")
        };
    }

    public void CompleteCurrentSemester()
    {
        if (currentSemesterIndex < semesters.Length)
        {
            semesters[currentSemesterIndex].SetCompleted(true);
            currentSemesterIndex += 1;
        }
    }

    public Semester GetCurrentSemester()
    {
        return semesters[currentSemesterIndex];
    }

    public int GetCurrentSemesterIndex()
    {
        return currentSemesterIndex;
    }

    public Semester[] GetAvailableSemesters()
    {
        return semesters;
    }

    
}
