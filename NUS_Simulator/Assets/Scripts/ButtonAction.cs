using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class ButtonAction : MonoBehaviour
{
    public void clickOnComputer() {
        Debug.Log("Computer Clicked");
    }

    public void clickOnMail() {
        Debug.Log("Mail Clicked");
        StudyManager.Instance.StopStudying(); 
    }

    public void ClickOnForwardButton() {
        SceneManager.LoadScene("InGameScene"); 
    }
}
