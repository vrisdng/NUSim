using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RewardScript : MonoBehaviour 
{
    [SerializeField] private GameObject snaPanel;
    
    [SerializeField] private GameObject itemsPanel;

    [SerializeField] private TextMeshProUGUI achievementText;
    
    private Student PLAYER = Student.Instance;
    void Start()
    {
        snaPanel.SetActive(true);
        itemsPanel.SetActive(false);
    }

    public void DisplayAchievements() 
    {
        string text = ""; 
        if (PLAYER.GetGPA() >= 4.8f)
        {
            text += "Dean's List \n";
        }
        if (PLAYER.GetMentalPoints() >= 100)
        {
            text += "Zen Mode \n";
        }
        if (PLAYER.GetPhysicalPoints() >= 100)
        {
            text += "Fitness Freak \n";
        }
        if (PLAYER.GetSocialPoints() >= 100)
        {
            text += "Social Butterfly \n"; 
        }
        achievementText.text = text; 
    }

    public void OnClickDisplayRewards() 
    {
        snaPanel.SetActive(false);
        itemsPanel.SetActive(true);
    }

    public void OnClickAReward() 
    {
        GameObject objSelected = EventSystem.current.currentSelectedGameObject;
        if (objSelected != null) {
            switch (objSelected.tag)
            {
                case "Plant":
                    PLAYER.AddPoints(15, 0, 0);
                    Debug.Log("Plant");
                    itemsPanel.SetActive(false); 
                    break;
                case "Chessboard":
                    PLAYER.AddPoints(0, 0, 15);
                    Debug.Log("CM");
                    SceneManager.LoadScene("SelectSemester");
                    itemsPanel.SetActive(false); 
                    break;
                case "Coffee-machine":
                    PLAYER.AddProductivity(0.1f);
                    Debug.Log("CB");
                    SceneManager.LoadScene("SelectSemester");
                    itemsPanel.SetActive(false); 
                    break;
                default: 
                    Debug.Log("No action");
                    break;
            }
        }
        SceneManager.LoadScene("SelectSemester");
    }


}