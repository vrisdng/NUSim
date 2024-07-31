using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void OnClick() {
        Debug.Log(Student.Instance.GetGameMode()); 
        if (Student.Instance.GetGameMode() == GameMode.Kiasu) {
            Student.Instance.SetGameMode(GameMode.Kiasu); 
        }
        Countdown.Instance.ResetCountdown();
        Student.Instance.Reset();
        Student.Instance.InitializeProductivity(); 
        if (SelectedModulesManager.Instance != null) {
            SelectedModulesManager.Instance.ResetAllProgress(); 
        } else {
            Debug.Log("StudyManager is null");
        }
        SceneManager.LoadScene("InGameScene");
    }

    public void OnClickMainMenu() {
        Countdown.Instance.ResetCountdown();
        Student.Instance.Reset();
        Student.Instance.InitializeProductivity(); 
        if (SelectedModulesManager.Instance != null) {
            SelectedModulesManager.Instance.ResetAllProgress(); 
        } else {
            Debug.Log("StudyManager is null");
        }
        SceneManager.LoadScene("Main Menu");
    }
} 