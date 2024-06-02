using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void clickOnModule() {
        SceneManager.LoadScene("InGameScene"); 
    }
}
