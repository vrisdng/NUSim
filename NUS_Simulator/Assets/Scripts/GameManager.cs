<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    private int activeModuleIndex = -1;
    private ModuleData moduleData;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
=======
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject playerPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
>>>>>>> Stashed changes
            Destroy(gameObject);
        }
    }

<<<<<<< Updated upstream
    void Start() {
        // Initialize moduleData here or assign it through inspector
    }

    void Update() {
        if (activeModuleIndex != -1) {
            Module activeModule = moduleData.GetModule(activeModuleIndex);
            float progressSpeed = activeModule.GetModuleDifficulty(); // Assuming difficulty represents speed
            ProgressBar progressBar = FindObjectOfType<ProgressBar>();
            progressBar?.UpdateModuleProgress(progressSpeed);
        }
    }

    public void SetActiveModuleIndex(int index) {
        activeModuleIndex = index;
    }

    public void SetModuleData(ModuleData data) {
        moduleData = data;
    }
}
=======
    public void StartGame()
    {
        Instantiate(playerPrefab);
    }

    public void ChangeState(GameState newState) {
        //OnBeforeStateChanged?.Invoke(currentState, newState);

        //State = newState;
        switch (newState) {
            case GameState.MainMenu:
                break;
            case GameState.CreateCharacter:
                break;
            case GameState.InGame:
                StartGame();
                break;
            case GameState.GameOver:
                break;
            case GameState.Examination:
                break;
        }
    }
}

[Serializable]
public enum GameState {
    MainMenu = 0,
    CreateCharacter = 1,
    InGame = 2,
    GameOver = 3,
    Examination = 4

}
>>>>>>> Stashed changes
