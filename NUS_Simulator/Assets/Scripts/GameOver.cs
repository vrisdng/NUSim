using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void OnClick() {
        Countdown.Instance.ResetCountdown();
        Student.Instance.Reset();
        ProgressBar.Instance.Reset();
        SceneManager.LoadScene("InGameScene");
    }
}