using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameLogic : MonoBehaviour
{
    public GameObject[] brickFormations;
    private int maxScore = 46;
    private int noFormations;
    private int formation;
    private int playerScore = 0;
    public Text scoreText;
    public GameObject gameSuccessScene;
    public GameObject gameOverScene;
    public GameObject paddle;
    public GameObject ball;
    private Student PLAYER = Student.Instance;


    public void addScore() {
        playerScore += 1;
        scoreText.text = playerScore.ToString();
        if (playerScore == maxScore){
            gameSuccess();
        }

    }

    public void gameOver() {
        MinigameManager minigame = new MinigameManager();
        minigame.AttachScore(playerScore);
        Destroy(ball);
        Destroy(paddle);
        gameOverScene.SetActive(true);
    }

    public void gameSuccess() {
        MinigameManager minigame = new MinigameManager();
        minigame.AttachScore(playerScore);
        Destroy(ball);
        Destroy(paddle);
        gameSuccessScene.SetActive(true);
    }

    public void OnClickQuit() {
        PLAYER.AddPoints(playerScore/2, playerScore/2, playerScore/2); 
        SceneManager.LoadScene("InGameScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        noFormations = brickFormations.Length;
        formation = Random.Range(0, noFormations);
        brickFormations[formation].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
