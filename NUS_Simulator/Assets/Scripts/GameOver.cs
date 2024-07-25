using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void OnClick() {
        Countdown.Instance.ResetCountdown();
        Student.Instance.Reset();
        Student.Instance.InitializeProductivity(); 
        if (StudyManager.Instance != null) {
            StudyManager.Instance.StopAllStudying(); 
        } else {
            Debug.Log("StudyManager is null");
        }
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
        if (StudyManager.Instance != null) {
            StudyManager.Instance.StopAllStudying(); 
        } else {
            Debug.Log("StudyManager is null");
        }
        if (SelectedModulesManager.Instance != null) {
            SelectedModulesManager.Instance.ResetAllProgress(); 
        } else {
            Debug.Log("StudyManager is null");
        }
        SceneManager.LoadScene("Main Menu");
    }
} 