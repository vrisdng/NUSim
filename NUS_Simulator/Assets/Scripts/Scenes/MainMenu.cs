using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene("TutorialScene");
    }

    public void Rules() {


    }

    public void Quit() {
        Application.Quit();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}