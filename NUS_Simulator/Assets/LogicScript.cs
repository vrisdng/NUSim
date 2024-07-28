using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    private Student PLAYER = Student.Instance;
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScene;

    void Start()
    {
        playerScore = 0;
    }

    public void addScore() {
        playerScore += 1;
        scoreText.text = playerScore.ToString(); 
    }

    public void gameOver() {
        MinigameManager minigameManager = FindObjectOfType<MinigameManager>();
        minigameManager.AttachScore(playerScore);
        gameOverScene.SetActive(true);
    }
    
}
