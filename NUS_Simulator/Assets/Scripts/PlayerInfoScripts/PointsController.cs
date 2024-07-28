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

    public void StartDecrementPoints(int decrementRate) 
    {
        StartCoroutine(DecrementPoints(decrementRate));
    }

    public IEnumerator DecrementPoints(int decrementRate) 
    {
        while(true) {
            Debug.Log("Points: " + player.GetMentalPoints() + " " + player.GetPhysicalPoints() + " " + player.GetSocialPoints());
            if (player.GetMentalPoints() <= 0 || player.GetPhysicalPoints() <= 0 || player.GetSocialPoints() <= 0) {
                SceneManager.LoadScene("GameOverScene"); 
            }
            player.DecrementMentalPoints(decrementRate);
            player.DecrementPhysicalPoints(decrementRate);
            player.DecrementSocialPoints(decrementRate);
            yield return new WaitForSeconds(0.5f);
            FindObjectOfType<PlayerInfoDisplay>().DisplayPlayerInfo();
        }
    }
}
