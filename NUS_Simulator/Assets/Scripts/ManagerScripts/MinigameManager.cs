using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    private DistractionEvent distractionEvent;
    private Student PLAYER = Student.Instance;
    private int playerScore;

    public void AttachDistraction(DistractionEvent distractionEvent)
    {
        this.distractionEvent = distractionEvent;
    }

    public void AttachScore(int score)
    {
        playerScore = score;
    }

    public void ProcessRewards()
    {
        if (distractionEvent == null)
        {
            Debug.LogError("Distraction event is null");
            PLAYER.AddPoints(0, 0, 0); 
            return;
        }
        if (PLAYER == null)
        {
            Debug.LogError("Player is null");
            return;
        }
        PLAYER.AddPoints(distractionEvent.GetMentalPoints(), distractionEvent.GetPhysicalPoints(), distractionEvent.GetSocialPoints());
    }

    public void ProcessRewardsFromStudying()
    {
        if (PLAYER == null)
        {
            Debug.LogError("Player is null");
            return;
        }
        Debug.Log(playerScore);
        if (this.playerScore >= 6) 
        {
            StudySceneScript.Instance.HandleMiniGameResultIfPassed(); 
        }
        else
        {
            StudySceneScript.Instance.HandleMiniGameResultIfNotPassed();
            Debug.Log("Player score is less than 6");
        }
    }

    public string GetRandomGame()
    {
        string[] games = new string[] { "flappy bird", "snake"}; 
        return games[Random.Range(0, games.Length)];
    }

    public void OnClickReturn()
    {
        Debug.Log("Clicked return?");
        if (SceneHistoryManager.Instance.GetPreviousScene() == "WorkingScene")
        {
            ProcessRewardsFromStudying();
            SceneManager.LoadScene("WorkingScene");
        }
        else {
            ProcessRewards();
            SceneManager.LoadScene("InGameScene"); 
        }
    }
}