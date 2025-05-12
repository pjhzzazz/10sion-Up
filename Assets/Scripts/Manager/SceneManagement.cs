using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement sceneManager {  get; private set; }

    private void Awake()
    {
        if (sceneManager != null)
        {
            Destroy(gameObject);
            return;
        }
        sceneManager = this;
        DontDestroyOnLoad(gameObject);
    }
    public void ToStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void ToStageSelectScene()
    {
        SceneManager.LoadScene("StageSelectScene");
    }

    public void ToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
