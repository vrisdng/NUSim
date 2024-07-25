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
            player.DecrementMentalPoints(2f);
            player.DecrementPhysicalPoints(2f);
            player.DecrementSocialPoints(2f);
            yield return new WaitForSeconds(1f);
            FindObjectOfType<PlayerInfoDisplay>().DisplayPlayerInfo();
        }
    }
}
