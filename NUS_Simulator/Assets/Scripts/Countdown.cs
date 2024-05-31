using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public static float remainingTime = 25f;

    public Countdown instance;

    void Awake() 
    {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateTimerDisplay(); // Update the timer display when the Countdown starts
    }

    void Update()
    {
        remainingTime -= Time.deltaTime;
        UpdateTimerDisplay(); // Update the timer display every frame
        if (remainingTime <= 0)
        {
            timerText.text = "00:00";
            SceneManager.LoadScene("ExamScene");
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Method to update remainingTime externally
    public void UpdateRemainingTime(float newTime)
    {
        remainingTime = newTime;
        UpdateTimerDisplay(); // Update the timer display when remainingTime is updated
    }
}
