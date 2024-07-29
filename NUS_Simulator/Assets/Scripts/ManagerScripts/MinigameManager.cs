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
            PLAYER.AddPoints(10, 10, 10); 
            return;
        }
        if (PLAYER == null)
        {
            Debug.LogError("Player is null");
            return;
        }
        PLAYER.AddPoints(distractionEvent.GetMentalPoints(), distractionEvent.GetPhysicalPoints(), distractionEvent.GetSocialPoints());
        SceneManager.LoadScene("DistractionScene");
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
            Debug.Log("Yes, player score is greater than 6");
            SceneManager.LoadScene("WorkingScene");
            //StudySceneScript.Instance.HandleMiniGameResultIfPassed(); 
        }
        else
        {
            Debug.Log("Player score is less than 6");
            SceneManager.LoadScene("WorkingScene");
            //StudySceneScript.Instance.HandleMiniGameResultIfNotPassed();
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
        if (distractionEvent == null)
        {
            Debug.LogError("Distraction event is null");
            PLAYER.AddPoints(10, 10, 10); 
            SceneManager.LoadScene("InGameScene");
        }
        PLAYER.AddPoints(distractionEvent.GetMentalPoints(), distractionEvent.GetPhysicalPoints(), distractionEvent.GetSocialPoints());
        SceneManager.LoadScene("InGameScene");
    }
}