using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SleepScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI firstText;
    [SerializeField] private TextMeshProUGUI secondText;
    [SerializeField] private TextMeshProUGUI thirdText;

    [SerializeField] private Button firstButton;
    [SerializeField] private Button secondButton;
    [SerializeField] private Button thirdButton;

    void Awake() 
    {
        firstText.text = "";
        secondText.text = "";
        thirdText.text = ""; 
    }
    public void OnHover()
    {
        // GetMouse
        if (firstButton) {
            firstText.text = "+10 MP \n + 10PP \n -15 minutes"; 
        } else if (secondButton) {
            secondText.text = "+30MP \n +30PP \n -1 hour"; 
        } else if (thirdButton) {
            thirdText.text = "+90MP \n +90PP \n -7 hours"; 
        }
    }

    public void OnClick()
    {
        Button clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        Countdown COUNTDOWN = Countdown.Instance; 
        Student PLAYER = Student.Instance;
        if (clickedButton = firstButton) {
            PLAYER.AddPointsFromSleeping(10, 10, 0);
            COUNTDOWN.UpdateRemainingTime(-15f);
        } else if (clickedButton = secondButton) {
            PLAYER.AddPointsFromSleeping(30, 30, 0);
            COUNTDOWN.UpdateRemainingTime(-60f);
        } else {
            PLAYER.AddPointsFromSleeping(90, 90, 0);
            COUNTDOWN.UpdateRemainingTime(-560f);
        }
    }
}