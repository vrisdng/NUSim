using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    private Student PLAYER = Student.Instance;
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScene;

    public void addScore() {
        playerScore += 1;
        scoreText.text = playerScore.ToString(); 
    }

    public void gameOver() {
        PLAYER.AddPoints(playerScore, playerScore, playerScore); 
        gameOverScene.SetActive(true);
    }
    
}
