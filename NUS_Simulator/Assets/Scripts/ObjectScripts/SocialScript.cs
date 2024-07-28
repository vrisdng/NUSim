using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SocialScript : MonoBehaviour
{

    [SerializeField] private Button firstButton;
    [SerializeField] private Button secondButton;
    [SerializeField] private Button thirdButton;
    [SerializeField] private Button cancelButton; 

    [SerializeField] private GameObject thisPanel; 

    private int clickCount = 0;
    private const int MaxClicks = 3;

    void Awake() 
    {
        thisPanel.SetActive(false); 
    }

    public void OnClick()
    {
        if (clickCount >= MaxClicks)
        {
            Debug.Log("Maximum of 3 social interactions reached.");
        }

        Button clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        Countdown countdown = Countdown.Instance;
        Student player = Student.Instance;

        if (clickedButton == firstButton) {
            HandleButtonClick(player, countdown, 0, 0, 30, -15f);
        } else if (clickedButton == secondButton) {
            HandleButtonClick(player, countdown, 0, 0, 50, -30f);
        } else if (clickedButton == thirdButton) {
            HandleButtonClick(player, countdown, 0, 0, 80, -60f);
        } else if (clickedButton == cancelButton) {
            Debug.Log("cancel");
            countdown.UpdateRemainingTime(0f);
            thisPanel.SetActive(false);
        }

        clickCount++;
        if (clickCount >= MaxClicks)
        {
            DisableSocialButtons();
        }
    }

    private void HandleButtonClick(Student player, Countdown countdown, int mPoints, int hPoints, int sPoints, float timeChange)
    {
        player.AddPointsFromSleeping(mPoints, hPoints, sPoints);
        countdown.UpdateRemainingTime(timeChange);
        thisPanel.SetActive(false);
    }

    private void DisableSocialButtons()
    {
        firstButton.interactable = false;
        secondButton.interactable = false;
        thirdButton.interactable = false;
    }
}

