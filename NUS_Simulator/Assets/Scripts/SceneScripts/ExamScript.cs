using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ExamScript : MonoBehaviour
{

    [SerializeField] ModuleData moduleData; 
    private Student PLAYER = Student.Instance;
    private GameOver gameOver; 
    public void OnClickGetReward() 
    {

        Module[] modules = moduleData.GetAllModules();

        for (int i = 0; i < modules.Length; i++)
        {
            PLAYER.AddModule(modules[i]);
        }

        Countdown.Instance.ResetCountdown();
        Student.Instance.Reset();
        SceneManager.LoadScene("RewardScene"); 
    }

    public void OnClickStartOver()
    {
        gameOver.OnClick(); 
    }
}