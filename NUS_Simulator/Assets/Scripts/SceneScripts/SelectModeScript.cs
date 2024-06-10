using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectModeScript : MonoBehaviour
{
    public void PlayLinear()
    {
        SceneManager.LoadScene("CreateCharacterScene");
    }
}
