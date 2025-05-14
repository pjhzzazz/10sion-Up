using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else Destroy(gameObject);
    }

    public void LoadScene(string sceneName, Action onLoaded = null)
    {
        StartCoroutine(LoadSceneAsync(sceneName, onLoaded));
    }

    private IEnumerator LoadSceneAsync(string sceneName, Action onLoaded)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        onLoaded?.Invoke();
    }

    public void ReloadCurrentScene() //새로고침용
    {
        string currentScene = SceneManager.GetActiveScene().name;
        LoadScene(currentScene);
    }
}
