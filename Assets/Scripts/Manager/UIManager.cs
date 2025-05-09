using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public StageManager stageManager;



    [Header("��ŸƮ ��")]
    public GameObject startObj;
    [SerializeField] private Button startBtn;
    [SerializeField] private Button startOptionBtn;

    [Header("�������� ��")]
    public GameObject stageObj;

    public List<Button> stageButtons;


    [Header("���� ��")]
    public GameObject mainObj;
    [SerializeField] private GameObject gameOverImg;
    [SerializeField] private GameObject optionImg;
    [SerializeField] private GameObject nextStageImg;

    [SerializeField] private Button mainOptionBtn;
    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button retryBtn;
    [SerializeField] private Button retryBtn2;
    [SerializeField] private Button mainMenuBtn;
    [SerializeField] private Button EndBtn;
    [SerializeField] private Button continueBtn;

    [Header("��")]
    [SerializeField] private Image[] starImg;

    private void Start()
    {
        string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (currentScene == "StartScene")
        {
            startObj.SetActive(true);
            stageObj.SetActive(false);
            mainObj.SetActive(false);
        }
        else if (currentScene == "StageScene")
        {
            startObj.SetActive(false);
            stageObj.SetActive(true);
            mainObj.SetActive(false);
        }
        else if (currentScene == "MainScene")
        {
            startObj.SetActive(false);
            stageObj.SetActive(false);
            mainObj.SetActive(true);
        }

            //��ŸƮ ��
            startBtn.onClick.AddListener(ToStage);
        startOptionBtn.onClick.AddListener(ShowOptionUI);

        //�������� ��
        for (int i = 0; i < stageButtons.Count; i++)
        {
            int index = i;
            stageButtons[i].onClick.AddListener(() => SelectedStage(index));
            stageButtons[i].interactable = ( i <= GameManager.gameManager.ClearedStage);
        }

        //���� ��
        gameOverImg.SetActive(false);
        optionImg.SetActive(false);
        nextStageImg.SetActive(false);

        mainOptionBtn.onClick.AddListener(ShowOptionUI);
        resumeBtn.onClick.AddListener(GamePlay);
        retryBtn.onClick.AddListener(Restart);
        retryBtn2.onClick.AddListener(Restart);
        mainMenuBtn.onClick.AddListener(ToStage);
        EndBtn.onClick.AddListener(ToStartMenu);
        continueBtn.onClick.AddListener(Continue);

    }

    // UI ��Ÿ����
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

    // UI�� ��ư ���� ��
    public void GamePlay()
    {
        optionImg.SetActive(false);
    }

    public void Restart()
    {
        stageManager.SpawnCharacters(stageManager.currentStage);
        optionImg.SetActive(false);
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
        stageManager.ToNextStage();
    }

    public void SelectedStage(int stageIndex) //�������� ���� ��
    {
        GameManager.gameManager.SelectedStageIndex = stageIndex;
        SceneManagement.sceneManager.ToMainScene();
    }

    public void ShowStars(int stars)
    {
        for (int i = 0; i < starImg.Length; i++)
        {
            starImg[i].enabled = i < stars;
        }
    }
}
