using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectModeScript : MonoBehaviour
{

    public GameModeManager gameModeManager = GameModeManager.Instance;
    public void PlayLinear()
    {
        gameModeManager.SetGameMode(GameMode.Linear);
        SceneManager.LoadScene("CreateCharacterScene");
    }

    public void PlayKiasu()
    {
        gameModeManager.SetGameMode(GameMode.Kiasu);
        SceneManager.LoadScene("CreateCharacterScene");
    }
}
