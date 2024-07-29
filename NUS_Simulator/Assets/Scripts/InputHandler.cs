using UnityEngine;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    GameObject objSelected = null;
    [SerializeField] private GameObject sleepPanel;
    [SerializeField] private GameObject socialPanel;
    [SerializeField] private GameObject laptop;
    private bool isSleepPanelActive = false;
    private bool isSocialPanelActive = false;

    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }
        
        CheckHitObject();
        Debug.Log(objSelected);
        if (objSelected == null)
        {
            
            return;
        }

        if (objSelected.tag == "Distraction")
        {
            SceneManager.LoadScene("DistractionScene");
            //StudyManager.Instance.StopAllStudying(); 
        }
        else if (objSelected.tag == "Work" && !isSleepPanelActive && !isSocialPanelActive)
        {
            SceneManager.LoadScene("WorkingScene");
        }
        else if (objSelected.tag == "SleepIcon")
        {
            socialPanel.SetActive(false);
            CloseSocialPanel();
            laptop.SetActive(false);
            sleepPanel.SetActive(true); 
            isSleepPanelActive = true; 
        }
        else if (objSelected.tag == "Social")
        {
            sleepPanel.SetActive(false);
            CloseSleepPanel();
            laptop.SetActive(false);
            socialPanel.SetActive(true);
            isSocialPanelActive = true; 
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

    public void CloseSocialPanel() 
    {
        isSleepPanelActive = false;
        isSocialPanelActive = false;
    }

    public void CloseSleepPanel() 
    {
        isSleepPanelActive = false;
        isSocialPanelActive = false;
    }
}
