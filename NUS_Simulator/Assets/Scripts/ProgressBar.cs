using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class ProgressBar : MonoBehaviour
{
    Image progressBar;
    [SerializeField] TextMeshProUGUI progressText;
    public float maxTime = 5.0f;
    private float currentTime = 0.0f;
    private float speed = 1.0f;

    void Start()
    {
        progressBar = GetComponent<Image>();
        progressBar.fillAmount = 0.0f;
    }

    void Update()
    {
        // update progress bar increment by time
        progressBar.fillAmount = currentTime / maxTime;
        progressText.text = (progressBar.fillAmount * 100).ToString("F0") + "%";

        // if DistractionEvent happens: call StopProgressBar()
        // if player chooses to do the distraction, call Deduct()
        // if player chooses not to do the distraction, continue as usual
        // if player chooses to switch to another module, call StopProgressBar() for this module and start the new module
        // should be able to keep track of the progress for each module separately

        if (currentTime < maxTime)
        {
            currentTime += Time.deltaTime * speed;
        }
        else 
        {
            Debug.Log("Completed!");
            progressText.text = "Completed!";
        }
    }

    // if an event happens, the progress bar halts
    public void StopProgressBar()
    {
        speed = 0.0f;
    }

    // if player chooses to do the distraction, deduct time from Countdown.cs

    public void Deduct(float time)
    {
        // 
    }
}
