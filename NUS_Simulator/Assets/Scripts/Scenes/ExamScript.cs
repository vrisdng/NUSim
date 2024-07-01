using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ExamScript : MonoBehaviour
{

    private SelectedModulesManager selectedModulesManager = SelectedModulesManager.Instance;
    private Student PLAYER = Student.Instance;
    public void OnClickGetReward() 
    {

        Module[] modules = selectedModulesManager.GetSelectedModules();

        for (int i = 0; i < modules.Length; i++)
        {
            PLAYER.AddModule(modules[i]);
        }

        Countdown.Instance.ResetCountdown();
        Student.Instance.Reset();
        SceneManager.LoadScene("RewardScene"); 
    }
}