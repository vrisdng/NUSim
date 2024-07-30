using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PointsController : MonoBehaviour
{
    private Student player = Student.Instance;

    public void StartDecrementPoints(float decrementRate) 
    {
        StartCoroutine(DecrementPoints(decrementRate));
    }

    public IEnumerator DecrementPoints(float decrementRate) 
    {
        while(player.GetMentalPoints() > 0 || player.GetPhysicalPoints() > 0 || player.GetSocialPoints() > 0)
        {
            player.DecrementMentalPoints(decrementRate);
            player.DecrementPhysicalPoints(decrementRate);
            player.DecrementSocialPoints(decrementRate);
            yield return new WaitForSeconds(1.2f);
            FindObjectOfType<PlayerInfoDisplay>().DisplayPlayerInfo();
        }

        if (player.GetMentalPoints() <= 0 || player.GetPhysicalPoints() <= 0 || player.GetSocialPoints() <= 0) {
                Debug.Log("Player has lost the game");
                SceneManager.LoadScene("GameOverScene"); 
            }
    }
}
