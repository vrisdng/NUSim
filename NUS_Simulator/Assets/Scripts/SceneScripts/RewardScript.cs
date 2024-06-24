using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RewardScript : MonoBehaviour 
{
    [SerializeField] private GameObject snaPanel;
    
    [SerializeField] private GameObject[] itemsPanels;

    [SerializeField] private TextMeshProUGUI achievementText;
    
    private Student PLAYER = Student.Instance;
    public GameModeManager GAMEMODE = GameModeManager.Instance;
    void Start()
    {
        snaPanel.SetActive(true);
        for (int i = 0; i < itemsPanels.Length; i++)
        {
            itemsPanels[i].SetActive(false);
        }
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
        // randomly select an item panel to display
        int randomIndex = Random.Range(0, itemsPanels.Length);
        print(randomIndex);
        itemsPanels[randomIndex].SetActive(true);
    }

    public void OnClickAReward() 
    {
        GameObject objSelected = EventSystem.current.currentSelectedGameObject;
        if (objSelected != null) {
            switch (objSelected.name)
            {
                case "Plant":
                    PLAYER.AddPoints(15, 0, 0);
                    Debug.Log("Plant");
                    break;
                case "Chessboard":
                    PLAYER.AddPoints(0, 0, 15);
                    Debug.Log("CM");
                    break;
                case "CoffeeMachine":
                    PLAYER.AdjustAllModulesProductivity(1.0f);
                    Debug.Log("CB");
                    break;
                default: 
                    Debug.Log("No action");
                    break;
            }
        } else {
            Debug.Log("Null object");
        
        }
        if (GAMEMODE.GetGameMode() == GameMode.Kiasu)
        {
            SceneManager.LoadScene("Select Modules");
        }
        else
        {
            SceneManager.LoadScene("SelectSemester");
        }
    }


}