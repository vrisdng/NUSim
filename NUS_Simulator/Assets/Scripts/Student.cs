
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Student {
    public static Student instance;
    private string name;
    private Points points;

    private bool shouldDecrementPoints;

    public Student(string name, float mentalPoints, float physicalPoints, float socialPoints)
    {
        this.name = name;
        this.points = new Points(mentalPoints, physicalPoints, socialPoints);
    }

    public static Student Instance {
        get {
            if (instance == null) {
                instance = new Student("player", 35, 35, 35);
            }
            return instance; 
        }
    }

    public bool getDecrementStatus()
    {
        return this.shouldDecrementPoints;
    }

    public void setShouldDecrementPoints(bool shouldDecrementPoints)
    {
        this.shouldDecrementPoints = shouldDecrementPoints;
    }

    public void AddPoints(DistractionEvent theEvent)
    {
        this.points.AddMentalPoints(theEvent.GetMentalPoints());
        this.points.AddPhysicalPoints(theEvent.GetPhysicalPoints());
        this.points.AddSocialPoints(theEvent.GetSocialPoints());
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
        instance = new Student("player", 35, 35, 35);
    }

}

