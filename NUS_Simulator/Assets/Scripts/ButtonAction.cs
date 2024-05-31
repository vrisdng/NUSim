using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    public void clickOnComputer() {
        Debug.Log("Computer Clicked");
        SceneManager.LoadScene("WorkingScene");
    }

    public void clickOnMail() {
        Debug.Log("Mail Clicked");
        SceneManager.LoadScene("DistractionScene");
    }
}
