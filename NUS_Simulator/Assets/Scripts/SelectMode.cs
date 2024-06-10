using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMode : MonoBehaviour 
{
    public void PlayLinear()
    {
        SceneManager.LoadScene("CreateCharacterScene");
    }
}

