using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SelectModulesScript : MonoBehaviour {

    public void OnClickNext() {
        SceneManager.LoadScene("InGameScene"); 
    }
}
