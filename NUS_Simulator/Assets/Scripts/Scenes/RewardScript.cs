using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class RewardScript : MonoBehaviour 
{
    [SerializeField] private GameObject snaPanel;
    
    [SerializeField] private GameObject[] itemsPanels;

    [SerializeField] private TextMeshProUGUI achievementText;
    
    private Student PLAYER = Student.Instance;
    public GameModeManager GAMEMODE = GameModeManager.Instance;

    private List<Reward> rewards = new List<Reward>
    {
        new Plant(),
        new Chessboard(),
        new CoffeeMachine(),
        new MP3(),
        new Milk(),
        new Bible(),
        new Tiramisu(),
        new Pills(),
        new Calculator(), 
        new Dumbbell(),
        new Notes(),
        new PYP(),
    };

    void Start()
    {
        snaPanel.SetActive(true);
        for (int i = 0; i < itemsPanels.Length; i++)
        {
            itemsPanels[i].SetActive(false);
        }
        DisplayAchievements();
    }

    private void DisplayAchievements()
    {
        TextUtility.DisplayAchievements(
            achievementText,
            PLAYER.GetGPA(),
            PLAYER.GetMentalPoints(),
            PLAYER.GetPhysicalPoints(),
            PLAYER.GetSocialPoints()
        );
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
        if (objSelected == null) {
            Debug.Log("No object selected");
        }

        Reward reward = rewards.Find(reward => reward.GetName() == objSelected.name);
        reward.RewardEffects();

        new Transition().TransitionLoopGameMode(GAMEMODE.GetGameMode()); 
    }
}