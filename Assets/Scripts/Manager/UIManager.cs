using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager uIManager;
    public StageManager stageManager;

    [SerializeField] private Button ResetBtn;

    [Header("스타트 씬")]
    public GameObject startObj;
    [SerializeField] private Button startBtn;
    [SerializeField] private Button startOptionBtn;

    [Header("스테이지 씬")]
    public GameObject stageSelectObj;
    [SerializeField] private Button backBtn;
    [SerializeField] private List<Button> stageButtons;

    [Header("메인 씬")]
    public GameObject mainObj;
    [SerializeField] private GameObject FailureImg;
    [SerializeField] private GameObject optionImg;
    [SerializeField] private GameObject SuccessImg;

    [SerializeField] private TextMeshProUGUI timeTxt;
    [SerializeField] private Button mainOptionBtn;
    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button OptionRetryBtn;
    [SerializeField] private Button mainMenuBtn;
    [SerializeField] private Button FailureRetryBtn;
    [SerializeField] private Button EndBtn;
    [SerializeField] private Button continueBtn;

    [Header("별")]
    public GameObject[] starObjects;

    void Awake()
    {
        if (uIManager != null && uIManager != this)
        {
            Destroy(this.gameObject);
            return;
        }
        uIManager = this;
    }

    private void Start()
    {
        ResetBtn.onClick.AddListener(ResetSaveData);

        string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        // 씬에 따른 UI 활성화
        if (currentScene == "StartScene")
        {
            startObj.SetActive(true);
            stageSelectObj.SetActive(false);
            mainObj.SetActive(false);

            startBtn.onClick.AddListener(ToStageSelect);
            startOptionBtn.onClick.AddListener(ShowOptionUI);
        }
        else if (currentScene == "StageSelectScene")
        {
            startObj.SetActive(false);
            stageSelectObj.SetActive(true);
            mainObj.SetActive(false);

            backBtn.onClick.AddListener(ToStartMenu);

            for (int i = 0; i < stageButtons.Count; i++)
            {
                int index = i;
                stageButtons[i].onClick.AddListener(() => SelectedStage(index));
                stageButtons[i].interactable = (i <= GameManager.gameManager.ClearedStage);


                Transform starParent = stageButtons[i].transform.Find("StarUI");

                GameObject[] stars = new GameObject[5];
                for (int j = 0; j < 5; j++)
                {
                    stars[j] = starParent.Find($"Star{j + 1}").gameObject;
                }

                int savedStars = SaveSystem.GetStars(i);
                ShowStars(stars, savedStars);
            }
        }
        else if (currentScene == "MainScene")
        {
            startObj.SetActive(false);
            stageSelectObj.SetActive(false);
            mainObj.SetActive(true);

            mainOptionBtn.onClick.AddListener(ShowOptionUI);
            resumeBtn.onClick.AddListener(Resume);
            OptionRetryBtn.onClick.AddListener(Restart);
            FailureRetryBtn.onClick.AddListener(Restart);
            mainMenuBtn.onClick.AddListener(ToStageSelect);
            EndBtn.onClick.AddListener(ToStageSelect);
            continueBtn.onClick.AddListener(Continue);
        }

        FailureImg.SetActive(false);
        optionImg.SetActive(false);
        SuccessImg.SetActive(false);
    }

    private void Update()
    {
        if (mainObj.activeSelf && !optionImg.activeSelf && !FailureImg.activeSelf && !SuccessImg.activeSelf)
        {
            int showPlayTime = (int)GameManager.gameManager.playTime;
            int minutes = showPlayTime / 60;
            int seconds = showPlayTime % 60;
            timeTxt.text = $"{minutes:D2}:{seconds:D2}";
        }
    }

    public void ShowStars(GameObject[] starObjects, int stars)
    {
        for (int i = 0; i < starObjects.Length; i++)
        {
            Transform emptyStar = starObjects[i].transform.Find("EmptyStar");
            Transform fullStar = starObjects[i].transform.Find($"Star");

            bool isShowStar = i < stars;
            {
                emptyStar.gameObject.SetActive(!isShowStar);
                fullStar.gameObject.SetActive(isShowStar);
            }
        }
    }

    // UI 나타나기
    public void ShowOptionUI()
    {
        GameManager.gameManager.PauseTime(true);
        optionImg.SetActive(true);
    }

    public void GameOverUI()
    {
        GameManager.gameManager.PauseTime(true);
        FailureImg.SetActive(true);
    }

    public void ShowNextStageUI()
    {
        SuccessImg.SetActive(true);
        GameManager.gameManager.PauseTime(true);
    }

    // UI안 버튼 누를 시
    public void Resume()
    {
        optionImg.SetActive(false);
        GameManager.gameManager.PauseTime(false);
    }

    public void Restart()
    {
        stageManager.SpawnCharacters(stageManager.currentStage);
        optionImg.SetActive(false);
        GameManager.gameManager.ResetStage();
    }

    public void ToStageSelect()
    {
        SceneManagement.sceneManager.ToStageSelectScene();
    }

    public void ToStartMenu()
    {
        SceneManagement.sceneManager.ToStartScene();
    }

    public void Continue()
    {
        stageManager.ToNextStage();
        SuccessImg.SetActive(false);
        GameManager.gameManager.ResetStage();
    }

    public void SelectedStage(int stageIndex)
    {
        GameManager.gameManager.SelectedStageIndex = stageIndex;
        GameManager.gameManager.ResetStage();
        SceneManagement.sceneManager.ToMainScene();
    }

    public void ResetSaveData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
