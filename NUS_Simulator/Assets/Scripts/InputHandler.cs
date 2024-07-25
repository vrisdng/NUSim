using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    GameObject objSelected = null;
    [SerializeField] private GameObject sleepPanel;
    [SerializeField] private GameObject socialPanel;
    private bool isSleepPanelActive = false;
    private bool isSocialPanelActive = false;

    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }
        
        CheckHitObject();
        if (objSelected == null)
        {
            return;
        }
        
        if (objSelected.tag == "Distraction")
        {
            SceneManager.LoadScene("DistractionScene");
            //StudyManager.Instance.StopAllStudying(); 
        }
        if (objSelected.tag == "Work" && !isSleepPanelActive && !isSocialPanelActive)
        {
            SceneManager.LoadScene("WorkingScene");
        }
        if (objSelected.tag == "SleepIcon")
        {
            sleepPanel.SetActive(true); 
            isSleepPanelActive = sleepPanel.activeSelf;
        }
        if (objSelected.tag == "Social")
        {
            socialPanel.SetActive(true);
            isSocialPanelActive = socialPanel.activeSelf;
        }  
    }

    void CheckHitObject() 
    {
        RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit2D.collider != null) 
        {
            objSelected = hit2D.collider.gameObject;
        }
    }

    public void CloseWorkPanel() {
        SceneManager.LoadScene("InGameScene");
    }

    public void CloseDistractionPanel() {
        SceneManager.LoadScene("InGameScene");
    }
}
