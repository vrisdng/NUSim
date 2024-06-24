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

    float timeDeductible = 7;
    Countdown countdown = Countdown.Instance;

    private int selectedDistractionIndex; 

    // a list of all the possible distractions

    void InitializeDistractions()
    {
        distractions = new DistractionEvent[30];
        distractions[0] = new DistractionEvent("You see a cute cat reel. You have a sudden urge to binge-watch on cat reels.", 0.5f, new Points(5, 0, 0));
        distractions[1] = new DistractionEvent("Your crush sends you a text message. You want to reply to it.", 0.5f, new Points(3, 0, 3));
        distractions[2] = new DistractionEvent("Your mom is calling you for a life update.", 0.5f, new Points(3, 0, 2));
        distractions[3] = new DistractionEvent("Your friend asks you to go gym together.", 0.5f, new Points(4, 10, 3));
        distractions[4] = new DistractionEvent("You suddenly remember that hilarious meme you saw last week and must find it to show your roommate.", 0.8f, new Points(6, 0, 10));
        distractions[5] = new DistractionEvent("Your pet dog starts barking at absolutely nothing. Investigation is required.", 0.5f, new Points(2, 5, 1));
        distractions[6] = new DistractionEvent("Your favorite snack is calling your name from the kitchen. Snack time is brain fuel, right?", 0.7f, new Points(4, 4, 2));
        distractions[7] = new DistractionEvent("You notice your plant is looking a little thirsty. Time to channel your inner botanist.", 0.4f, new Points(2, 0, 1));
        distractions[8] = new DistractionEvent("Netflix just released a new episode of your favorite series. One episode can't hurt, can it?", 0.9f, new Points(7, 0, 4));
        distractions[9] = new DistractionEvent("Your room is suddenly too messy to concentrate. Time for a cleaning spree!", 0.8f, new Points(5, 2, 5));
        distractions[10] = new DistractionEvent("You get a notification that there's a sale on your favorite online store. Shopping cart, here I come!", 0.7f, new Points(6, 0, 3));
        distractions[11] = new DistractionEvent("You start daydreaming about your next vacation. Mental vacation planning is productive, right?", 0.6f, new Points(3, 0, 4));
        distractions[12] = new DistractionEvent("You decide to reorganize your entire computer file system. This is definitely productive procrastination.", 0.8f, new Points(5, 3, 1));
        distractions[13] = new DistractionEvent("Your roommate starts playing your favorite song loudly. Dance party break?", 0.7f, new Points(4, 0, 5));
        distractions[14] = new DistractionEvent("You feel the sudden urge to start a new hobby. Why not learn to knit right now?", 0.6f, new Points(4, 0, 1));
        distractions[15] = new DistractionEvent("A random philosophical question pops into your head. Time to deep-dive into an existential crisis.", 0.8f, new Points(6, 3, 0));
        distractions[16] = new DistractionEvent("Your favorite YouTuber just uploaded a new video. Immediate viewing required.", 0.9f, new Points(7, 1, 2));
        distractions[17] = new DistractionEvent("You realize you haven't checked social media in the last 10 minutes. Social obligations must be met.", 0.7f, new Points(5, 2, 0));
        distractions[18] = new DistractionEvent("You hear an ice cream truck outside. Ice cream is essential for studying, obviously.", 0.5f, new Points(3, 0, 4));
        distractions[19] = new DistractionEvent("You feel a sudden need to rearrange your furniture. Feng shui for better focus!", 0.8f, new Points(5, 3, 1));
        distractions[20] = new DistractionEvent("Your best friend invites you to a surprise party they are throwing.", 0.6f, new Points(2, 0, 10));
        distractions[21] = new DistractionEvent("You receive an invitation to join a group chat with some old friends.", 0.5f, new Points(1, 0, 8));
        distractions[22] = new DistractionEvent("Your neighbor invites you over for a coffee and a chat.", 0.5f, new Points(2, 0, 9));
        distractions[23] = new DistractionEvent("A classmate calls to discuss a project but ends up chatting about life.", 0.4f, new Points(2, 0, 7));
        distractions[24] = new DistractionEvent("You get an invite to a virtual game night with your friends.", 0.7f, new Points(3, 0, 10));
        distractions[25] = new DistractionEvent("You join a video call with your family for a spontaneous catch-up.", 0.6f, new Points(3, 0, 8));
        distractions[26] = new DistractionEvent("You decide to attend a local community meetup.", 0.7f, new Points(4, 0, 9));
        distractions[27] = new DistractionEvent("An old friend messages you out of the blue to catch up.", 0.4f, new Points(1, 0, 7));
        distractions[28] = new DistractionEvent("Your friend invites you to join them for a fun outdoor activity.", 0.8f, new Points(4, 5, 10));
        distractions[29] = new DistractionEvent("You receive a phone call from a relative you haven't spoken to in a while.", 0.5f, new Points(2, 0, 6));
    }

    
    void Start()
    {
        InitializeDistractions();
        RandomDistractionEvent();
        Time.timeScale = 0; 
    }

    
    void Update()
    {
        
    }

    void RandomDistractionEvent()
    {
        float totalProbability = 0f;
        for (int i = 0; i < distractions.Length; i++)
        {
            totalProbability += distractions[i].distractionProbability;
        }

        float random = Random.Range(0f, totalProbability);
        float sum = 0f;
        for (int i = 0; i < distractions.Length; i++)
        {
            sum += distractions[i].distractionProbability;
            if (random <= sum)
            {
                distractionText.text = distractions[i].distractionText;
                mpText.text = "MP: +" + distractions[i].GetMentalPoints();
                ppText.text = "PP: +" + distractions[i].GetPhysicalPoints();
                spText.text = "SP: +" + distractions[i].GetSocialPoints();
                selectedDistractionIndex = i;
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
        SceneManager.LoadSceneAsync("InGameScene");
        Time.timeScale = 1; 
    }

    public void HandleNoButton()
    {

        Debug.Log("Back to main screen!");
        SceneManager.LoadSceneAsync("InGameScene");
        Time.timeScale = 1; 
    }
}

public class DistractionEvent
{
    public string distractionText;
    [Range(0f, 19f)] public float distractionProbability;
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
