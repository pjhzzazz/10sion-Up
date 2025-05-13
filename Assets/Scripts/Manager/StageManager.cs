using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{

    [Header("캐릭터 프리팹")]
    public GameObject RedPlayerPrefab;
    public GameObject BluePlayerPrefab;

    [Header("스테이지 추가")]
    public GameObject[] stageParents;
    public int currentStage;

    private void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "MainScene")
        {
            currentStage = GameManager.gameManager.SelectedStageIndex;
            ChangeStage(currentStage);
        }
    }

    public void ChangeStage(int stageIndex) // 스테이지 전환
    {
        for (int i = 0; i < stageParents.Length; i++)
        {
                bool isActive = (i == stageIndex);
                stageParents[i].SetActive(isActive);
        }

        currentStage = stageIndex;
        SpawnCharacters(stageIndex);
    }

    public void SpawnCharacters(int stageIndex) // 캐릭터 스폰
    {
        Transform stagePosition = stageParents[stageIndex].transform;
        Transform RedSpawn = stagePosition.Find("RedSpawn");
        Transform BlueSpawn = stagePosition.Find("BlueSpawn");

        foreach (var Redplayer in GameObject.FindGameObjectsWithTag("RedPlayer"))
        {
            Destroy(Redplayer);
        }

        foreach (var Blueplayer in GameObject.FindGameObjectsWithTag("BluePlayer"))
        {
            Destroy(Blueplayer);
        }

        GameObject RedPlayer = Instantiate(RedPlayerPrefab, RedSpawn.position, Quaternion.identity);
        GameObject BluePlayer = Instantiate(BluePlayerPrefab, BlueSpawn.position, Quaternion.identity);
    }

    public void ToNextStage()
    {
        int nextStageIndex = GameManager.gameManager.SelectedStageIndex + 1;

        if (nextStageIndex < stageParents.Length)
        {
            ChangeStage(nextStageIndex);
            GameManager.gameManager.SelectedStageIndex = nextStageIndex;
        }
        else
        {
            SceneManagement.sceneManager.ToStageSelectScene();
        }
    }
}
