using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class ExamScript : MonoBehaviour
{

    private SelectedModulesManager selectedModulesManager = SelectedModulesManager.Instance;
    private Student PLAYER = Student.Instance;
    public void OnClickGetReward() 
    {
        Debug.Log(PLAYER.GetGameMode());

        Module[] modules = selectedModulesManager.GetSelectedModules();

        for (int i = 0; i < modules.Length; i++)
        {
            PLAYER.AddModule(modules[i]);
        }

        Countdown.Instance.ResetCountdown();
        if (PLAYER.GetGameMode() == GameMode.Linear) {
            SemesterManager.Instance.CompleteCurrentSemester();
            if (SemesterManager.Instance.GetCurrentSemester().GetName() == "Year 4 Semester 2")
            {
                SceneManager.LoadScene("EndingScene");
            }
            else
            {
                SceneManager.LoadScene("RewardScene");
            }
        }
        else if (PLAYER.GetGameMode() == GameMode.Kiasu)
        {
            SceneManager.LoadScene("RewardScene");
        }
    }
}