using System;
using TMPro;
using UnityEngine;

public class PlayerInfoDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsInfo;

    private void Awake()
    {
        DisplayPlayerInfo();
    }

    public void DisplayPlayerInfo()
    {
        if (Student.Instance != null)
        {
            pointsInfo.text = "MP: " + Mathf.RoundToInt(Student.Instance.GetMentalPoints()) + "\n" +
                              "PP: " + Mathf.RoundToInt(Student.Instance.GetPhysicalPoints()) + "\n" +
                              "SP: " + Mathf.RoundToInt(Student.Instance.GetSocialPoints());
        } else {
            Debug.LogError("Student instance is null");
        }
    }
}
