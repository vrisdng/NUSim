using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class RandomDistraction : MonoBehaviour
{
    public DistractionEvent[] distractions;
    [SerializeField] TextMeshProUGUI distractionText; 
    [SerializeField] TextMeshProUGUI mpText;
    [SerializeField] TextMeshProUGUI ppText;
    [SerializeField] TextMeshProUGUI spText;

    public Player player = new Player("Player", 0, 0, 0);

    private int selectedDistractionIndex; 

    // a list of all the possible distractions

    void InitializeDistractions()
    {
        distractions = new DistractionEvent[4];
        distractions[0] = new DistractionEvent("You see a cat", 0.5f, new Points(1, 0, 0));
        distractions[1] = new DistractionEvent("You see a dog", 0.5f, new Points(1, 0, 0));
        distractions[2] = new DistractionEvent("Your mom calls you", 0.5f, new Points(1, 0, 1));
        distractions[3] = new DistractionEvent("Your friend asks you to go gym", 0.5f, new Points(1, 1, 1));
        // TODO: getNextEvent and map and names for each event
    }

    
    void Start()
    {
        InitializeDistractions();
        RandomDistractionEvent();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomDistractionEvent();
        }
    }

    void RandomDistractionEvent()
    {
        float random = Random.Range(0f, 4f);
        float sum = 0f;
        for (int i = 0; i < distractions.Length; i++)
        {
            sum += distractions[i].distractionProbability;
            if (random <= sum)
            {
                selectedDistractionIndex = i;
                distractionText.text = distractions[i].distractionText;
                mpText.text = "MP: +" + distractions[i].GetMentalPoints();
                ppText.text = "PP: +" + distractions[i].GetPhysicalPoints();
                spText.text = "SP: +" + distractions[i].GetSocialPoints();
                /* debug log
                Debug.Log(distractions[i].distractionText);
                Debug.Log("MP: +" + distractions[i].GetMentalPoints());
                Debug.Log("PP: +" + distractions[i].GetPhysicalPoints());
                Debug.Log("SP: +" + distractions[i].GetSocialPoints());
                */ 
                break;
            }
        } 
    }
    public void HandleYesButton()
    {
        Debug.Log("Yes button clicked");
        player.AddPoints(distractions[selectedDistractionIndex]);
        Debug.Log("Player's MP: " + player.points.mentalPoints);
    }

    public void HandleNoButton()
    {
        Debug.Log("Back to main screen!");
        SceneManager.LoadScene("InGameScene");
    }

}

public class DistractionEvent
{
    public string distractionText;
    [Range(0f, 1f)] public float distractionProbability;
    private Points points;

    public DistractionEvent(string distractionText, float distractionProbability, Points points)
    {
        this.distractionText = distractionText;
        this.distractionProbability = distractionProbability;
        this.points = points;
    }

    public int GetMentalPoints()
    {
        return points.mentalPoints;
    }

    public int GetPhysicalPoints()
    {
        return points.physicalPoints;
    }

    public int GetSocialPoints()
    {
        return points.socialPoints;
    }
}

public class Points
{
    public int mentalPoints;
    public int physicalPoints;
    public int socialPoints;
    public Points(int mentalPoints, int physicalPoints, int socialPoints)
    {
        this.mentalPoints = mentalPoints;
        this.physicalPoints = physicalPoints;
        this.socialPoints = socialPoints;
    }

    public void AddMentalPoints(int points)
    {
        mentalPoints += points;
    }
    public void AddPhysicalPoints(int points)
    {
        physicalPoints += points;
    }

    public void AddSocialPoints(int points)
    {
        socialPoints += points;
    }
}

public class Player {
    public string name;
    public Points points;

    public Player(string name, int mentalPoints, int physicalPoints, int socialPoints)
    {
        this.name = name;
        this.points = new Points(mentalPoints, physicalPoints, socialPoints);
    }

    public void AddPoints(DistractionEvent theEvent)
    {
        this.points.AddMentalPoints(theEvent.GetMentalPoints());
        this.points.AddPhysicalPoints(theEvent.GetPhysicalPoints());
        this.points.AddSocialPoints(theEvent.GetSocialPoints());
    }
}

