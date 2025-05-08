using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("스타트 씬")]
    [SerializeField] private Button startBtn;
    [SerializeField] private Button startOptionBtn;

    [Header("스테이지 씬")]
    public List<Button> stageButtons;


    [Header("메인 씬")]
    [SerializeField] private GameObject gameOverImg;
    [SerializeField] private GameObject optionImg;
    [SerializeField] private GameObject nextStageImg;

    [SerializeField] private Button mainOptionBtn;
    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button retryBtn;
    [SerializeField] private Button mainMenuBtn;
    [SerializeField] private Button EndBtn;
    [SerializeField] private Button continueBtn;

    private void Start()
    {
        //스타트 씬
        startBtn.onClick.AddListener(ToStage);
        startOptionBtn.onClick.AddListener(ShowOptionUI);

        //스테이지 씬
        for (int i = 0; i < stageButtons.Count; i++)
        {
            int index = i;
            stageButtons[i].onClick.AddListener(() => SelectedStage(index));
            stageButtons[i].interactable = ( i <= stageButtons.Count + 1 );
        }

        //메인 씬
        gameOverImg.SetActive(false);
        optionImg.SetActive(false);
        nextStageImg.SetActive(false);

        mainOptionBtn.onClick.AddListener(ShowOptionUI);
        resumeBtn.onClick.AddListener(GamePlay);
        retryBtn.onClick.AddListener(Restart);
        mainMenuBtn.onClick.AddListener(ToStage);
        EndBtn.onClick.AddListener(ToStartMenu);
        continueBtn.onClick.AddListener(Continue);

    }

    // UI 나타나기
    public void ShowOptionUI()
    {
        optionImg.SetActive(true);
    }

    public void GameOverUI()
    {
        gameOverImg.SetActive(true);
    }

    public void ShowNextStageUI()
    {
        nextStageImg.SetActive(true);
    }

    // UI안 버튼 누를 시
    public void GamePlay()
    {
        optionImg.SetActive(false);
    }

    public void Restart()
    {
        StageManager.stageManager.SpawnCharacters(StageManager.stageManager.currentStage);
    }

    public void ToStage()
    {
        SceneManagement.sceneManager.ToStageScene();
    }

    public void ToStartMenu()
    {
        SceneManagement.sceneManager.ToStartScene();
    }

    public void Continue()
    {
        StageManager.stageManager.ToNextStage();
    }

    public void SelectedStage(int stage)
    {
        StageManager.stageManager.SpawnCharacters(stage);
        SceneManagement.sceneManager.ToMainScene();
    }
}
