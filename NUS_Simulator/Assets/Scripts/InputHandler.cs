using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    GameObject objSelected = null;
    [SerializeField] private GameObject sleepPanel;
    private bool isSleepPanelActive = false;

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
            StudyManager.Instance.StopStudying(); 
        }
        if (objSelected.tag == "Work" && !isSleepPanelActive)
        {
            SceneManager.LoadScene("WorkingScene");
        }
        if (objSelected.tag == "SleepIcon")
        {
            sleepPanel.SetActive(true); 
            isSleepPanelActive = true;
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
