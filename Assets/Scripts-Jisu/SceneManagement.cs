using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement sceneManager {  get; private set; }

    private UIManager uiManager;

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

    public void ToStageScene()
    {
        SceneManager.LoadScene("StageScene");
    }

    public void ToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
