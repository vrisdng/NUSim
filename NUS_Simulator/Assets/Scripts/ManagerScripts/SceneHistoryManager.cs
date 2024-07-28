using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneHistoryManager : MonoBehaviour
{
    private static SceneHistoryManager instance;
    private Stack<string> sceneHistory = new Stack<string>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (mode == LoadSceneMode.Single)
        {
            if (sceneHistory.Count == 0 || sceneHistory.Peek() != scene.name)
            {
                sceneHistory.Push(scene.name);
            }
        }
    }

    public string GetPreviousScene()
    {
        if (sceneHistory.Count > 1)
        {
            string currentScene = sceneHistory.Pop();
            string previousScene = sceneHistory.Peek();
            sceneHistory.Push(currentScene);
            Debug.Log("Current Scene: " + currentScene);
            Debug.Log("Previous Scene: " + previousScene);
            return previousScene;
        }
        return null;
    }

    public static SceneHistoryManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("SceneHistoryManager").AddComponent<SceneHistoryManager>();
            }
            return instance;
        }
    }

    public void RegisterCurrentScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (sceneHistory.Count == 0 || sceneHistory.Peek() != currentSceneName)
        {
            sceneHistory.Push(currentSceneName);
        }
    }
}
