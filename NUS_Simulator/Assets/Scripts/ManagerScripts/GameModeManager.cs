using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    Linear,
    Kiasu
}
public class GameModeManager : MonoBehaviour
{
    public static GameModeManager Instance { get; private set; }

    private GameMode CurrentGameMode; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetGameMode(GameMode mode)
    {
        CurrentGameMode = mode;
    }

    public GameMode GetGameMode()
    {
        return CurrentGameMode;
    }
}

