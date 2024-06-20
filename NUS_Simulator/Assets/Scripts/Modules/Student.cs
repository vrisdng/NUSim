
using System.Collections;
using System.Reflection;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Student {
    public static Student instance;
    private string name;
    private Points points;

    private Module[] modules = new Module[5]; 

    public Student(string name, float mentalPoints, float physicalPoints, float socialPoints)
    {
        this.name = name;
        this.points = new Points(mentalPoints, physicalPoints, socialPoints);
    }

    public Student(string name, float mentalPoints, float physicalPoints, float socialPoints, Module[] modules)
    {
        this.name = name;
        this.points = new Points(mentalPoints, physicalPoints, socialPoints);
        this.modules = modules;
    }

    public static Student Instance {
        get {
            if (instance == null) {
                instance = new Student("player", 30, 30, 30);
            }
            return instance; 
        }
    }

    public bool IsAnyPointZero()
    {
        return this.GetMentalPoints() <= 0 || this.GetPhysicalPoints() <= 0 || this.GetSocialPoints() <= 0;
    }

    public void AddPoints(DistractionEvent theEvent)
    {
        this.points.AddMentalPoints(theEvent.GetMentalPoints());
        this.points.AddPhysicalPoints(theEvent.GetPhysicalPoints());
        this.points.AddSocialPoints(theEvent.GetSocialPoints());
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

    public void Reset() {
        instance = new Student("player", 30, 30, 30);
    }

}

