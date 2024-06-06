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
    [SerializeField] TextMeshProUGUI mP;
    [SerializeField] TextMeshProUGUI pP;
    [SerializeField] TextMeshProUGUI sP;

    public GameObject mailIcon; 

    private Coroutine pointsDecrementCoroutine;
    static float _MAIL_INTERVAL = 2.25f; 

    void Start()
    {
        PLAYER = Student.Instance; 
        DisplayPlayerInfo(); 
        mailIcon.SetActive(false);
        GameObject panel = GameObject.FindGameObjectWithTag("StudyingPanel");
        panel.SetActive(false);
    }

    void StartPointsDecrement() 
    {
        if (pointsDecrementCoroutine == null) {
            pointsDecrementCoroutine = StartCoroutine(PointsDecrement());
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DisplayMailIcon());
        StartPointsDecrement(); 
    }

    void DisplayPlayerInfo() 
    {
        Debug.Log("Player's MP: " + PLAYER.GetMentalPoints());
        mP.text = "MP: " + Mathf.RoundToInt(PLAYER.GetMentalPoints());
        pP.text = "PP: " + Mathf.RoundToInt(PLAYER.GetPhysicalPoints()); 
        sP.text = "SP: " + Mathf.RoundToInt(PLAYER.GetSocialPoints());
    }

    Boolean IsAnyPointZero()
    {
        return PLAYER.GetMentalPoints() <= 0 || PLAYER.GetPhysicalPoints() <= 0 || PLAYER.GetSocialPoints() <= 0;
    }

    IEnumerator PointsDecrement() 
    {
        while(true) {
            if (IsAnyPointZero()) {
                SceneManager.LoadScene("GameOverScene");
                break;
            }
            PLAYER.DecrementMentalPoints(1.7f);
            PLAYER.DecrementPhysicalPoints(1.9f);
            PLAYER.DecrementSocialPoints(1.9f);
            yield return new WaitForSeconds(1f);
            DisplayPlayerInfo();
        }
    }
    
    IEnumerator DisplayMailIcon() 
    {
        while(true) {
            yield return new WaitForSeconds(_MAIL_INTERVAL);
            mailIcon.SetActive(true);
        }
    }
}
