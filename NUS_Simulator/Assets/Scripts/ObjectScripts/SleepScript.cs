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
        Countdown COUNTDOWN = Countdown.Instance; 
        Student PLAYER = Student.Instance;
        if (clickedButton == firstButton) {
            PLAYER.AddPointsFromSleeping(10, 10, 0);
            COUNTDOWN.UpdateRemainingTime(-15f);
            thisPanel.SetActive(false); 
        } else if (clickedButton == secondButton) {
            PLAYER.AddPointsFromSleeping(30, 30, 0);
            COUNTDOWN.UpdateRemainingTime(-30f);
            thisPanel.SetActive(false); 
        } else if (clickedButton == thirdButton){
            PLAYER.AddPointsFromSleeping(60, 60, 0);
            COUNTDOWN.UpdateRemainingTime(-60f);
            thisPanel.SetActive(false); 
        } else if (clickedButton == cancelButton) {
            Debug.Log("cancel"); 
            COUNTDOWN.UpdateRemainingTime(-0f);
            thisPanel.SetActive(false); 
        }
    }
}