using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainScreenDisplay : MonoBehaviour
{
    public Student PLAYER; 
    [SerializeField] TextMeshProUGUI mP;
    [SerializeField] TextMeshProUGUI pP;
    [SerializeField] TextMeshProUGUI sP;

    void Start()
    {
        PLAYER = Student.Instance; 
        DisplayPlayerInfo(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisplayPlayerInfo() 
    {
        Debug.Log("Player's MP: " + PLAYER.GetMentalPoints());
        mP.text = "MP: " + PLAYER.GetMentalPoints();
        pP.text = "PP: " + PLAYER.GetPhysicalPoints(); 
        sP.text = "SP: " + PLAYER.GetSocialPoints();
    }
}
