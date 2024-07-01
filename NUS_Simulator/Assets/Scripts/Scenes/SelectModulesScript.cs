using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using System;

// For ModuleSelectScene
public class SelectModulesScript : MonoBehaviour {
    public void OnClickNext() {
        SceneManager.LoadScene("InGameScene"); 
    }
}
