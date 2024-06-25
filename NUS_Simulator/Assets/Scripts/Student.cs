
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Student {
    public static Student instance;
    private string name;
    private Points points;

    private string faculty; 
    private float GPA = 0.0f; 

    private Dictionary<string, float> productivity;

    private Module[] modules = new Module[45]; 

    public Student(string name, float mentalPoints, float physicalPoints, float socialPoints)
    {
        this.name = name;
        this.points = new Points(mentalPoints, physicalPoints, socialPoints);
    }

    public Student(string name, float mentalPoints, float physicalPoints, float socialPoints, Dictionary<string, float> productivity)
    {
        this.name = name;
        this.points = new Points(mentalPoints, physicalPoints, socialPoints);
        this.productivity = productivity;
    }

    public Student(string name, float mentalPoints, float physicalPoints, float socialPoints, Module[] modules)
    {
        this.name = name;
        this.points = new Points(mentalPoints, physicalPoints, socialPoints);
        this.modules = modules;
    }

    public Student(string name, string faculty, float mentalPoints, float physicalPoints, float socialPoints, Module[] modules)
    {
        this.name = name;
        this.faculty = faculty; 
        this.points = new Points(mentalPoints, physicalPoints, socialPoints);
        this.modules = modules;
    }

    public static Student Instance {
        get {
            if (instance == null) {
                instance = new Student("player", 100, 100, 100);
            }
            return instance; 
        }
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
        this.points.AddMentalPoints(mpoints);
        this.points.AddPhysicalPoints(ppoints);
        this.points.AddSocialPoints(spoints);
    }

    public void AddPoints(DistractionEvent theEvent)
    {
        this.points.AddMentalPoints(theEvent.GetMentalPoints());
        this.points.AddPhysicalPoints(theEvent.GetPhysicalPoints());
        this.points.AddSocialPoints(theEvent.GetSocialPoints());
    }

    public void AddPointsFromSleeping(float mpoints, float ppoints, float spoints)
    {
        this.points.AddMentalPoints(mpoints);
        this.points.AddPhysicalPoints(ppoints);
        this.points.AddSocialPoints(spoints);
    }

    public void InitializeProductivity()
    {
        productivity = new Dictionary<string, float>
        {
            { "default", 1.0f },
            { "CS", 1.0f },
            { "MA", 1.0f },
            { "UE", 1.0f },
        };
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
        this.points.DecrementMentalPoints(points);
    }

    public void DecrementPhysicalPoints(float points)
    {
        this.points.DecrementPhysicalPoints(points);
    }

    public void DecrementSocialPoints(float points)
    {
        this.points.DecrementSocialPoints(points);
    }

    public float GetMentalPoints() {
        return points.mentalPoints;
    }

    public float GetPhysicalPoints() {
        return points.physicalPoints;
    }

    public float GetSocialPoints() {
        return points.socialPoints; 
    }

    public void SetMentalPoints(float number) {
        this.points.mentalPoints = number;
    }

    public void SetPhysicalPoints(float number) {
        this.points.physicalPoints = number;
    }

    public void SetSocialPoints(float number) {
        this.points.socialPoints = number; 
    }
    
    public float GetProductivityOfModule(string moduleType)
    {
        return 1.0f;
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

