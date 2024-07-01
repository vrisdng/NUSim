using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour 
{
    [SerializeField] private GameObject askingPanel;
    [SerializeField] private GameObject tutorialPanel;

    [SerializeField] private GameObject page1;
    [SerializeField] private GameObject page2;
    [SerializeField] private GameObject page3;

    void Awake() 
    {
        askingPanel.SetActive(true);
        tutorialPanel.SetActive(false);
    }

    public void OnClickStartNow()
    {
        SceneManager.LoadScene("SelectMode");
    }

    public void OnClickStartTutorial() 
    {
        tutorialPanel.SetActive(true);
        askingPanel.SetActive(false);
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);
    }

    public void OnClickNextPage()
    {
        if (page1.activeSelf) 
        {
            page1.SetActive(false);
            page2.SetActive(true);
        }
        else if (page2.activeSelf) 
        {
            page2.SetActive(false);
            page3.SetActive(true);
        }
        else if (page3.activeSelf) 
        {
            SceneManager.LoadScene("SelectMode");
        }
    }
}
