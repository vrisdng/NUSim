using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSemesterScript : MonoBehaviour 
{
    public void OnChooseSemester(int semester)
    {
        SceneManager.LoadScene("Select Modules"); 
    }
}
