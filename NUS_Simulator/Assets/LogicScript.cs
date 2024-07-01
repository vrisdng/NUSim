using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScene;
    
    public void addScore() {
        playerScore += 1;
        scoreText.text = playerScore.ToString(); 
    }

    public void gameOver() {
        gameOverScene.SetActive(true);
    }
    
}
