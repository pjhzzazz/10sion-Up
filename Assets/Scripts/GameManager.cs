using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    [SerializeField] private UIManager uiManager;

    public int stars { get; private set;}

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

    public void NumberOfStar(float jewelTotal, float gainedJewel, float timeTotal, float takingTime)
    {
        float jewelRate = gainedJewel / jewelTotal;
        float timeRate = (timeTotal / 5) / takingTime;
        timeRate = Mathf.Min(timeRate, 1f);

        float point = jewelRate * 0.5f + timeRate * 0.5f;

        if (point > 0.8f) stars = 5;
        else if (point > 0.6f) stars = 4;
        else if (point > 0.4f) stars = 3;
        else if (point > 0.2f) stars = 2;
        else stars = 1;

        uiManager.ShowStars(stars);
    }
}
