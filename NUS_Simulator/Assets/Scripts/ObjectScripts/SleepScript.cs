using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SleepScript : MonoBehaviour
{

    [SerializeField] private Button firstButton;
    [SerializeField] private Button secondButton;
    [SerializeField] private Button thirdButton;
    [SerializeField] private Button cancelButton; 

    [SerializeField] private GameObject thisPanel; 

    void Awake() 
    {
        thisPanel.SetActive(false); 
    }

    public void OnClick()
    {
        Button clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        Countdown countdown = Countdown.Instance;
        Student player = Student.Instance;

        if (clickedButton == firstButton) {
            HandleButtonClick(player, countdown, 10, 10, 0, -15f);
        } else if (clickedButton == secondButton) {
            HandleButtonClick(player, countdown, 30, 30, 0, -30f);
        } else if (clickedButton == thirdButton) {
            HandleButtonClick(player, countdown, 60, 60, 0, -60f);
        } else if (clickedButton == cancelButton) {
            Debug.Log("cancel");
            countdown.UpdateRemainingTime(0f);
            thisPanel.SetActive(false);
        }
    }

    private void HandleButtonClick(Student player, Countdown countdown, int sleepPoints, int healthPoints, int stressPoints, float timeChange)
    {
        player.AddPointsFromSleeping(sleepPoints, healthPoints, stressPoints);
        countdown.UpdateRemainingTime(timeChange);
        thisPanel.SetActive(false);
    }
}

