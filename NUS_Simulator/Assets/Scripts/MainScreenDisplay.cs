using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal.Internal;
public class MainScreenDisplay : MonoBehaviour
{
    public static Student PLAYER = Student.Instance; 

    public GameObject mailIcon; 

    public PlayerInfoDisplay PlayerInfoDisplay;
    public PointsController PointsController;

    void Start()
    {
        Debug.Log(PLAYER.GetName()); 
        PlayerInfoDisplay.DisplayPlayerInfo(); 
        PointsController.Initialize(PLAYER);
        PointsController.StartDecrementPoints(1f);
        
        mailIcon.SetActive(false);
    }

    void Update()
    {
        if (PLAYER.IsAnyPointZero()) {
            SceneManager.LoadScene("GameOverScene");
        }
    }
    
}
