using System;
using TMPro;
using UnityEngine;

public class PlayerInfoDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsInfo;
    [SerializeField] private TextMeshProUGUI playerName;

    private void Awake()
    {
        DisplayPlayerInfo();
    }

    public void DisplayPlayerInfo()
    {
        if (Student.Instance != null)
        {
            pointsInfo.text = "Mental Health: " + Mathf.RoundToInt(Student.Instance.GetMentalPoints()) + "\n" +
                              "Physical Health: " + Mathf.RoundToInt(Student.Instance.GetPhysicalPoints()) + "\n" +
                              "Social Life: " + Mathf.RoundToInt(Student.Instance.GetSocialPoints());
            // playerName.text = "Hello " + Student.Instance.GetName();
        } else {
            Debug.LogError("Student instance is null");
        }
    }
}
