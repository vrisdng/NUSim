using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void OnClick() {
        Student.Instance.Reset();
        SceneManager.LoadScene("InGameScene");
    }
}