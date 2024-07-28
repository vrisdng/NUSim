using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public void OnClickReturn()
    {
        SceneManager.LoadScene("Main Menu");
    }
}