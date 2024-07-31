using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectModeScript : MonoBehaviour
{

    public GameModeManager gameModeManager = GameModeManager.Instance;
    private Student student = Student.Instance;
    public void PlayLinear()
    {
        student.SetGameMode(GameMode.Linear);
        SceneManager.LoadScene("CreateCharacterScene");
    }

    public void PlayKiasu()
    {
        student.SetGameMode(GameMode.Kiasu);
        SceneManager.LoadScene("CreateCharacterScene");
    }
}
