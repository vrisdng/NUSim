using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.AI;
public class MainScreenDisplay : MonoBehaviour
{
    public static Student PLAYER = Student.Instance; 

    public GameObject mailIcon; 

    public PlayerInfoDisplay PlayerInfoDisplay;
    public PointsController PointsController;

    void Awake()
    {
        Debug.Log(PLAYER.GetName()); 
        PlayerInfoDisplay.DisplayPlayerInfo(); 
        Debug.Log("Player's points: " + Student.Instance.GetMentalPoints() + Student.Instance.GetPhysicalPoints() + Student.Instance.GetSocialPoints());
        PointsController.StartDecrementPoints(1f);
        
        Debug.Log("This points controller is running");
        
        mailIcon.SetActive(false);
    }

    void GameOver()
    {
        if (PLAYER.IsAnyPointZero())
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
    
}
