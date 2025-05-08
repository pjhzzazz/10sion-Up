using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    [SerializeField] private UIManager uiManager;

    public int ClearedStage { get; private set; }

    private void Awake()
    {
        if (gameManager != null)
        {
            Destroy(gameObject);
            return;
        }
        gameManager = this;
        DontDestroyOnLoad(gameObject); 
    }

    private void Start()
    {
        ClearedStage = SaveSystem.GetClearedStage();
        MainMenu();
    }

    public void SaveStageClear(int stage)
    {
        SaveSystem.SaveClearedStage(stage); // PlayerPrefs 저장
        ClearedStage = Mathf.Max(ClearedStage, stage); // 최신 상태로 반영
    }

    public void MainMenu() //시작
    {
        SceneManagement.sceneManager.ToStartScene();
    }

    public void NextStage() //성공 시 다음 스테이지 이동 UI
    {
        uiManager.ShowNextStageUI();
    }

    public void GameOver() //캐릭터 죽을 시 UI
    {
        uiManager.GameOverUI();
    }

    public void AddScore()
    {

    }
}
