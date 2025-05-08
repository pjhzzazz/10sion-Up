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
        SaveSystem.SaveClearedStage(stage); // PlayerPrefs ����
        ClearedStage = Mathf.Max(ClearedStage, stage); // �ֽ� ���·� �ݿ�
    }

    public void MainMenu() //����
    {
        SceneManagement.sceneManager.ToStartScene();
    }

    public void NextStage() //���� �� ���� �������� �̵� UI
    {
        uiManager.ShowNextStageUI();
    }

    public void GameOver() //ĳ���� ���� �� UI
    {
        uiManager.GameOverUI();
    }

    public void AddScore()
    {

    }
}
