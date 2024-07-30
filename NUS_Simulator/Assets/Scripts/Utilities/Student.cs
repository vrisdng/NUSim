
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Student {
    private static Student instance;
    private string name;
    private MentalPoints mentalPoints;
    private PhysicalPoints physicalPoints;
    private SocialPoints socialPoints;

    private string faculty; 
    private float GPA = 0.0f; 

    private Dictionary<string, float> productivity;

    private Module[] modules = new Module[45]; 

    public Student(string name, float mentalPoints, float physicalPoints, float socialPoints)
    {
        this.name = name;
        this.mentalPoints = new MentalPoints(mentalPoints);
        this.physicalPoints = new PhysicalPoints(physicalPoints);
        this.socialPoints = new SocialPoints(socialPoints);
    }

    public Student(string name, float mentalPoints, float physicalPoints, float socialPoints, Dictionary<string, float> productivity)
    {
        this.name = name;
        this.mentalPoints = new MentalPoints(mentalPoints);
        this.physicalPoints = new PhysicalPoints(physicalPoints);
        this.socialPoints = new SocialPoints(socialPoints);
        this.productivity = productivity;
    }

    public static Student Instance {
        get {
            if (instance == null) {
                instance = new Student("player", 100, 100, 100);
            }
            return instance; 
        }
    }

    public void InitializeProductivity()
    {
        productivity = new Dictionary<string, float>
        {
            { "default", 1.0f },
            { "College of Design and Engineering", 1.0f },
            { "NUS Business School", 1.0f},
            { "Arts and Social Science", 1.0f},
            { "Science", 1.0f},
            { "Computing", 1.0f},
        };
    }

    public bool IsAnyPointZero()
    {
        return this.GetMentalPoints() <= 0 || this.GetPhysicalPoints() <= 0 || this.GetSocialPoints() <= 0;
    }

    public void SetName(string name) {
        this.name = name;
    }

    public string GetName() {
        return this.name;
    }

    public void SetFaculty(string faculty) {
        this.faculty = faculty; 
    }

    public string GetFaculty() {
        return this.faculty; 
    }

    public void SetGPA(float gpa) {
        this.GPA = gpa; 
    }

    public float GetGPA() {
        return this.GPA;
    }
    public void AddPoints(float mpoints, float ppoints, float spoints)
    {
        this.mentalPoints.Add(mpoints);
        this.physicalPoints.Add(ppoints);
        this.socialPoints.Add(spoints);
    }

    public void AddPointsFromSleeping(float mpoints, float ppoints, float spoints)
    {
        this.mentalPoints.Add(mpoints);
        this.physicalPoints.Add(ppoints);
        this.socialPoints.Add(spoints);
    }

    public void AddModule(Module module)
    {
        for (int i = 0; i < modules.Length; i++)
        {
            if (modules[i] == null)
            {
                modules[i] = module;
                break;
            }
        }
    }

    public void DecrementMentalPoints(float points)
    {
        if (this.mentalPoints.Value - points < 0)
        {
            this.mentalPoints.Value = 0;
        }
        else
        {
            this.mentalPoints.Decrement(points);
        }
    }

    public void DecrementPhysicalPoints(float points)
    {
        if (this.physicalPoints.Value - points < 0)
        {
            this.physicalPoints.Value = 0;
        }
        else
        {
            this.physicalPoints.Decrement(points);
        }
    }

    public void DecrementSocialPoints(float points)
    {
        if (this.socialPoints.Value - points < 0)
        {
            this.socialPoints.Value = 0;
        }
        else
        {
            this.socialPoints.Decrement(points);
        }
    }

    public void SetMentalPoints(float points)
    {
        this.mentalPoints.Value = points;
    }

    public void SetPhysicalPoints(float points)
    {
        this.physicalPoints.Value = points;
    }

    public void SetSocialPoints(float points)
    {
        this.socialPoints.Value = points;
    }

    public float GetMentalPoints() {
        return mentalPoints.Value;
    }

    public float GetPhysicalPoints() {
        return physicalPoints.Value;
    }

    public float GetSocialPoints() {
        return socialPoints.Value; 
    }
    
    public float GetProductivityOfModule(string moduleType)
    { 
        if (productivity.ContainsKey(moduleType))
        {
            return productivity[moduleType];
        }
        else
        {
        Debug.LogWarning("Module type not found: " + moduleType);
        return 1.0f; 
        }
    }

    public void AdjustProductivity(string moduleType, float adjustment)
    {
        productivity[moduleType] += adjustment;
    }

    public void AdjustAllModulesProductivity(float adjustment)
    {
        foreach (Module module in modules)
        {
            if (module != null)
            {
                AdjustProductivity(module.moduleType, adjustment);
            }
        }
    }

    public void Reset() {
        instance = new Student(this.name, 100, 100, 100);
    }
}

