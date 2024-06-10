using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSemester : MonoBehaviour 
{
    public void OnChooseSemester(int semester)
    {
        SceneManager.LoadScene("Select Modules"); 
    }
}

