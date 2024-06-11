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

    private Coroutine pointsDecrementCoroutine;
    static float _MAIL_INTERVAL = 2.25f;

    public PlayerInfoDisplay PlayerInfoDisplay;
    public PointsController PointsController;

    void Start()
    {
        PLAYER = Student.Instance; 
        PlayerInfoDisplay.DisplayPlayerInfo(); 
        PointsController.Initialize(PLAYER);

        mailIcon.SetActive(false);
    }

    void Update()
    {
        StartCoroutine(DisplayMailIcon());
    }
    
    IEnumerator DisplayMailIcon() 
    {
        while(true) {
            yield return new WaitForSeconds(_MAIL_INTERVAL);
            mailIcon.SetActive(true);
        }
    }
}
