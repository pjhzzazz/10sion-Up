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

    public int SelectedStageIndex { get; set; } = 0;
    public int ClearedStage = 0;

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
        ClearedStage = SaveSystem.GetClearedStage(); // �ҷ�����
        MainMenu();
    }

    public void SaveStageClear(int stageIndex) // ����
    {
        SaveSystem.SaveClearedStage(stageIndex);
        ClearedStage = Mathf.Max(ClearedStage, stageIndex);
    }

    public void MainMenu() //����
    {
        SceneManagement.sceneManager.ToStartScene();
    }

    public void Success() //���� �� UI
    {
        uiManager.ShowNextStageUI();
    }

    public void GameOver() //ĳ���� ���� �� UI
    {
        uiManager.GameOverUI();
    }

    public void NumberOfStar(float totalJewel, float gainedJewel, float takingTime) //�� ���� ���
    {

        float jewelRate = gainedJewel / totalJewel;
        float timeRate = 40 / takingTime;
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
