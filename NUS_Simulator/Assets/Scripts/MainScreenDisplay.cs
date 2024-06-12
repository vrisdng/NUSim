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
    public static Student PLAYER; 

    public GameObject mailIcon; 

    // [SerializeField] private GameObject sleepPanel; 

    private Coroutine pointsDecrementCoroutine;

    public PlayerInfoDisplay PlayerInfoDisplay;
    public PointsController PointsController;

    void Start()
    {
        PLAYER = Student.Instance; 
        Debug.Log(PLAYER.GetName()); 
        PlayerInfoDisplay.DisplayPlayerInfo(); 
        PointsController.Initialize(PLAYER);

        mailIcon.SetActive(false);
        // sleepPanel.SetActive(false); 
    }

    void Update()
    {

    }
    
}
