using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class ButtonAction : MonoBehaviour
{
    public GameObject studyPanel;
    public void clickOnComputer() {
        Debug.Log("Computer Clicked");
    }

    public void clickOnMail() {
        Debug.Log("Mail Clicked");
    }

    public void clickOnStudyButton() {
        Debug.Log("Study Button Clicked");
        if (studyPanel.activeSelf == false) {
            studyPanel.SetActive(true);
        } else {
            studyPanel.SetActive(false);
        }
    }

    public void ClickOnForwardButton() {
        SceneManager.LoadScene("InGameScene"); 
    }
}
