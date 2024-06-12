using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PointsController : MonoBehaviour
{
    private Student player;

    public void Initialize(Student student)
    {
        player = student;
        StartCoroutine(DecrementPoints());
    }

    private IEnumerator DecrementPoints() 
    {
        while(true) {
            if (player.GetMentalPoints() < 0 || player.GetPhysicalPoints() < 0 || player.GetSocialPoints() < 0) {
                SceneManager.LoadSceneAsync("GameOverScene"); 
            }
            player.DecrementMentalPoints(1.7f);
            player.DecrementPhysicalPoints(1.9f);
            player.DecrementSocialPoints(1.9f);
            yield return new WaitForSeconds(1f);
            FindObjectOfType<PlayerInfoDisplay>().DisplayPlayerInfo();
        }
    }
}
