using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PointsController : MonoBehaviour
{
    private Student player;

    public void Initialize(Student student)
    {
        player = student;
    }

    public void StartDecrementPoints() 
    {
        StartCoroutine(DecrementPoints());
    }

    public IEnumerator DecrementPoints() 
    {
        while(true) {
            Debug.Log("Points: " + player.GetMentalPoints() + " " + player.GetPhysicalPoints() + " " + player.GetSocialPoints());
            if (player.GetMentalPoints() <= 0 || player.GetPhysicalPoints() <= 0 || player.GetSocialPoints() <= 0) {
                SceneManager.LoadScene("GameOverScene"); 
            }
            player.DecrementMentalPoints(0f);
            player.DecrementPhysicalPoints(0f);
            player.DecrementSocialPoints(0f);
            yield return new WaitForSeconds(0f);
            FindObjectOfType<PlayerInfoDisplay>().DisplayPlayerInfo();
        }
    }
}
