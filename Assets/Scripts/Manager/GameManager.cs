using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState { StartMenu, SelectingStage, Playing, Paused, GameOver, GameClear }
    public GameState CurrentState { get; private set; }

    public int ClearedStage = -1;
    public int selectedStage;
    public float playTime;
    private float gainedGem;
    public int LastGainedStars => StarRatingUI.Instance?.stars ?? 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        if (SaveSystem.SaveExists())
        {
            LoadGame();
        }
        else
        {
            Debug.Log("저장 파일 없음.");
        }
    }

    private void Start()
    {
        ChangeState(GameState.StartMenu);
    }

    private void Update()
    {
        if (CurrentState == GameState.Playing)
        {
            playTime += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameClear();
        }
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;

        switch (newState)
        {
            case GameState.StartMenu:
                UIManager.Instance.OpenUI(UIType.StartMenu);
                break;

            case GameState.SelectingStage:
                UIManager.Instance.OpenUI(UIType.SelectingStage);
                break;

            case GameState.Playing:
                Time.timeScale = 1;
                playTime = 0;
                gainedGem = 0;
                AudioManager.Instance.PlayBGM("Stage1");
                break;

            case GameState.Paused:
                UIManager.Instance.OpenUI(UIType.Option);
                Time.timeScale = 0;
                break;

            case GameState.GameOver:
                UIManager.Instance.OpenUI(UIType.Failure);
                Time.timeScale = 0;
                break;

            case GameState.GameClear:
                UIManager.Instance.OpenUI(UIType.Success);
                Time.timeScale = 0;
                break;
        }
    }

    public void StartGame(int selectedStage) //게임 플레이
    {
        this.selectedStage = selectedStage;

        SceneController.Instance.LoadScene("GameScene", () =>
        {
            ChangeState(GameState.Playing);
            StageController.Instance.ChangeStage(selectedStage);
        });
    }
    public void AddGem(int Gem) // 득점
    {
        gainedGem += Gem;
    }

    public void PauseGame() //
    {
        Debug.Log("PauseGame called");
        ChangeState(GameState.Paused);
    }

    public void ResumeGame() //
    {
        Time.timeScale = 1;
    }

    public void GameOver() // 캐릭터 죽을 시
    {
        ChangeState(GameState.GameOver);
    }

    public void GameClear() // 클리어 시 UI 불러오기, 저장 처리 기능
    {
        ChangeState(GameState.GameClear);
        StarRatingUI.Instance.PointToStar(gainedGem, playTime);

        SaveGame();
    }

    public void NextStage()
    {
        ChangeState(GameState.Playing);
        StageController.Instance.ToNextStage(selectedStage + 1);
    }

    void SaveGame()
    {
        GameData data = SaveSystem.LoadGame() ?? new GameData();

        ClearedStage = Mathf.Max(selectedStage, ClearedStage);
        data.stageIndex = ClearedStage;

        StageStarData existingData = data.stageStars.Find(s => s.stageIndex == selectedStage);
        if (existingData != null)
        {
            if (StarRatingUI.Instance.stars > existingData.stars)
            {
                existingData.stars = StarRatingUI.Instance.stars;
            }
        }
        else
        {
            data.stageStars.Add(new StageStarData { stageIndex = selectedStage, stars = StarRatingUI.Instance.stars });
        }

        SaveSystem.SaveGame(data);
    }

    void LoadGame()
    {
        GameData data = SaveSystem.LoadGame();
        if (data != null)
        {
            ClearedStage = data.stageIndex;
            int stars = data.stageStars.Find(s => s.stageIndex == ClearedStage)?.stars ?? 0;
        }
    }

    public void ReturnToSelectingStage()
    {
        SceneController.Instance.LoadScene("MainMenuScene", () =>
        {
            ChangeState(GameState.SelectingStage);
            AudioManager.Instance.PlayBGM("bgm1");
        });
    }

    public void ReturnToStartMenu()
    {
        SceneController.Instance.LoadScene("MainMenuScene", () =>
        {
            ChangeState(GameState.StartMenu);
        });
    }

    public void GameStory()
    {
        UIManager.Instance.OpenUI(UIType.Story);
        AudioManager.Instance.PlayBGM("bgm1");
    }
}
