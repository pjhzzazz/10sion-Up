using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    public int stars { get; private set;}

    public int SelectedStageIndex { get; set; } = 0;
    public int ClearedStage = 0;

    public float playTime = 0;
    private float gainedGem = 0;
    
    public bool IsPaused = false;

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
        ClearedStage = SaveSystem.GetClearedStage(); // 불러오기
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainScene" && !IsPaused)
        {
            playTime += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
                Success();
        }
    }

    public void ResetStage()
    {
        playTime = 0;
        gainedGem = 0;
        PauseTime(false);
    }

    public void Success() //성공 시 UI
    {
        Debug.Log($"[Success 호출 시점] SelectedStageIndex = {SelectedStageIndex}, ClearedStage = {ClearedStage}");
        NumberOfStar(gainedGem, playTime);
        SaveStageClear(SelectedStageIndex);
        UIManager.uIManager.ShowNextStageUI();
        UIManager.uIManager.ShowStars(UIManager.uIManager.starObjects, stars);
    }

    public void GameOver() //캐릭터 죽을 시 UI
    {
        UIManager.uIManager.GameOverUI();
    }

    public void PauseTime(bool stop)
    {
        IsPaused = stop;
    }

    public void AddGem(float Gem)
    {
        gainedGem += Gem;
    }
    public void SaveStageClear(int stageIndex) // 저장
    {
        SaveSystem.SaveClearedStage(stageIndex, stars);
        ClearedStage = Mathf.Max(ClearedStage, stageIndex);
    }

    public void NumberOfStar(float gainedGem, float takingTime) //별 개수 계산
    {
        float jewelRate = gainedGem / 10;
        float timeRate = 40 / takingTime;
        timeRate = Mathf.Min(timeRate, 1f);

        float point = jewelRate * 0.5f + timeRate * 0.5f;

        if (point > 0.8f) stars = 5;
        else if (point > 0.6f) stars = 4;
        else if (point > 0.4f) stars = 3;
        else if (point > 0.2f) stars = 2;
        else stars = 1;

        UIManager.uIManager.ShowStars(UIManager.uIManager.starObjects, stars);
    }
}
