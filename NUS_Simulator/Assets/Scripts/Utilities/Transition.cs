using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Transition
{
    public void TransitionLoopGameMode(GameMode mode) 
    {
        if (mode == GameMode.Kiasu)
        {
            SceneManager.LoadScene("Select Modules");
        }
        else {
            SceneManager.LoadScene("SelectSemester");
        }
    }
}