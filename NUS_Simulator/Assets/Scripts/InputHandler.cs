using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    GameObject objSelected = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckHitObject();
            if (objSelected != null)
            {
                if (objSelected.tag == "Distraction")
                {
                    SceneManager.LoadScene("DistractionScene");
                    StudyManager.Instance.StopStudying(); 
                }
                if (objSelected.tag == "Work")
                {
                    SceneManager.LoadScene("WorkingScene");
                }
            }
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
