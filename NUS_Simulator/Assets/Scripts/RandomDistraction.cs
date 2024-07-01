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

    private static readonly (string text, float probability, float mp, float pp, float sp)[] distractionData = 
    {
        ("You see a cute cat reel. You have a sudden urge to binge-watch on cat reels.", 0.5f, 5, 0, 0),
        ("Your crush sends you a text message. You want to reply to it.", 0.5f, 3, 0, 3),
        ("Your mom is calling you for a life update.", 0.5f, 3, 0, 2),
        ("Your friend asks you to go gym together.", 0.5f, 4, 10, 3),
        ("You suddenly remember that hilarious meme you saw last week and must find it to show your roommate.", 0.8f, 6, 0, 10),
        ("Your pet dog starts barking at absolutely nothing. Investigation is required.", 0.5f, 2, 5, 1),
        ("Your favorite snack is calling your name from the kitchen. Snack time is brain fuel, right?", 0.7f, 4, 4, 2),
        ("You notice your plant is looking a little thirsty. Time to channel your inner botanist.", 0.4f, 2, 0, 1),
        ("Netflix just released a new episode of your favorite series. One episode can't hurt, can it?", 0.9f, 7, 0, 4),
        ("Your room is suddenly too messy to concentrate. Time for a cleaning spree!", 0.8f, 5, 2, 5),
        ("You get a notification that there's a sale on your favorite online store. Shopping cart, here I come!", 0.7f, 6, 0, 3),
        ("You start daydreaming about your next vacation. Mental vacation planning is productive, right?", 0.6f, 3, 0, 4),
        ("You decide to reorganize your entire computer file system. This is definitely productive procrastination.", 0.8f, 5, 3, 1),
        ("Your roommate starts playing your favorite song loudly. Dance party break?", 0.7f, 4, 0, 5),
        ("You feel the sudden urge to start a new hobby. Why not learn to knit right now?", 0.6f, 4, 0, 1),
        ("A random philosophical question pops into your head. Time to deep-dive into an existential crisis.", 0.8f, 6, 3, 0),
        ("Your favorite YouTuber just uploaded a new video. Immediate viewing required.", 0.9f, 7, 1, 2),
        ("You realize you haven't checked social media in the last 10 minutes. Social obligations must be met.", 0.7f, 5, 2, 0),
        ("You hear an ice cream truck outside. Ice cream is essential for studying, obviously.", 0.5f, 3, 0, 4),
        ("You feel a sudden need to rearrange your furniture. Feng shui for better focus!", 0.8f, 5, 3, 1),
        ("Your best friend invites you to a surprise party they are throwing.", 0.6f, 2, 0, 10),
        ("You receive an invitation to join a group chat with some old friends.", 0.5f, 1, 0, 8),
        ("Your neighbor invites you over for a coffee and a chat.", 0.5f, 2, 0, 9),
        ("A classmate calls to discuss a project but ends up chatting about life.", 0.4f, 2, 0, 7),
        ("You get an invite to a virtual game night with your friends.", 0.7f, 3, 0, 10),
        ("You join a video call with your family for a spontaneous catch-up.", 0.6f, 3, 0, 8),
        ("You decide to attend a local community meetup.", 0.7f, 4, 0, 9),
        ("An old friend messages you out of the blue to catch up.", 0.4f, 1, 0, 7),
        ("Your friend invites you to join them for a fun outdoor activity.", 0.8f, 4, 5, 10),
        ("You receive a phone call from a relative you haven't spoken to in a while.", 0.5f, 2, 0, 6)
    };

    void InitializeDistractions()
    {
        distractions = new DistractionEvent[distractionData.Length];
        for (int i = 0; i < distractionData.Length; i++)
        {
            var data = distractionData[i];
            distractions[i] = new DistractionEvent(data.text, data.probability, data.mp, data.pp, data.sp);
        }
    }
    
    void Start()
    {
        InitializeDistractions();
        RandomDistractionEvent();
        Time.timeScale = 0; 
    }

    
    void Update()
    {
        if (Student.Instance.IsAnyPointZero()) {
            SceneManager.LoadScene("GameOverScene");
        }
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
                SetDistractionText(distractions[i]);
                selectedDistractionIndex = i;
                break;
            }
        } 
    }

    void SetDistractionText(DistractionEvent distraction)
    {
        distractionText.text = distraction.distractionText;
        mpText.text = $"MP: +{distraction.GetMentalPoints()}";
        ppText.text = $"PP: +{distraction.GetPhysicalPoints()}";
        spText.text = $"SP: +{distraction.GetSocialPoints()}";
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
    [Range(0f, 29f)] public float distractionProbability;
    private MentalPoints mentalPoints;
    private PhysicalPoints physicalPoints;
    private SocialPoints socialPoints;

    public DistractionEvent(string distractionText, float distractionProbability, float mentalPoints, float physicalPoints, float socialPoints)
    {
        this.distractionText = distractionText;
        this.distractionProbability = distractionProbability;
        this.mentalPoints = new MentalPoints(mentalPoints);
        this.physicalPoints = new PhysicalPoints(physicalPoints);
        this.socialPoints = new SocialPoints(socialPoints);
    }

    public float GetMentalPoints()
    {
        return mentalPoints.Value;
    }

    public float GetPhysicalPoints()
    {
        return physicalPoints.Value;
    }

    public float GetSocialPoints()
    {
        return socialPoints.Value;
    }
}
