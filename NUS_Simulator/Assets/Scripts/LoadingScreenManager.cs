using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;

public class LoadingScreenManager : MonoBehaviour
{
    public static LoadingScreenManager Instance; 
    public GameObject m_LoadingScreenObject;

    public void Start()
    {
        m_LoadingScreenObject.SetActive(false);
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SwitchToScene(string sceneName)
    {
        m_LoadingScreenObject.SetActive(true);
        StartCoroutine(SwitchToSceneAsync(sceneName));
    }

    IEnumerator SwitchToSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            Debug.Log("Loading progress: " + asyncLoad.progress);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        m_LoadingScreenObject.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}