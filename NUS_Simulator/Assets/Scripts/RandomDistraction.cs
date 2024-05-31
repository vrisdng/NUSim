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

    float timeDeductible = 10; 
    Countdown countdown = Countdown.Instance;

    private int selectedDistractionIndex; 

    // a list of all the possible distractions

    void InitializeDistractions()
    {
        distractions = new DistractionEvent[4];
        distractions[0] = new DistractionEvent("You see a cat", 0.5f, new Points(1, 0, 0));
        distractions[1] = new DistractionEvent("You see a dog", 0.5f, new Points(1, 0, 0));
        distractions[2] = new DistractionEvent("Your mom calls you", 0.5f, new Points(1, 0, 2));
        distractions[3] = new DistractionEvent("Your friend asks you to go gym", 0.5f, new Points(1, 3, 2));
        // TODO: getNextEvent and map and names for each event
    }

    
    void Start()
    {
        InitializeDistractions();
        RandomDistractionEvent();
        Time.timeScale = 0; 
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
                break;
            }
        } 
    }
    public void HandleYesButton()
    {
        Debug.Log("Yes button clicked");
        Student player = Student.Instance;
        player.AddPoints(distractions[selectedDistractionIndex]);
        Debug.Log("Player's MP: " + player.GetMentalPoints());
        countdown.UpdateRemainingTime(-timeDeductible);
        SceneManager.LoadScene("InGameScene");
        Time.timeScale = 1; 
    }

    public void HandleNoButton()
    {

        Debug.Log("Back to main screen!");
        SceneManager.LoadScene("InGameScene");
        Time.timeScale = 1; 
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

    public float GetMentalPoints()
    {
        return points.mentalPoints;
    }

    public float GetPhysicalPoints()
    {
        return points.physicalPoints;
    }

    public float GetSocialPoints()
    {
        return points.socialPoints;
    }
}
