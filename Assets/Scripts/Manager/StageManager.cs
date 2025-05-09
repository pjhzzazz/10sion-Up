using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{

    [Header("캐릭터 프리팹")]
    public GameObject fireboyPrefab;
    public GameObject watergirlPrefab;

    [Header("스테이지 추가")]
    public Transform[] stageParents;
    public int currentStage;

    private void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "MainScene")
        {
            SpawnCharacters(currentStage);
        }
    }

    public void SpawnCharacters(int stage)
    {
        Debug.Log($"[SpawnCharacters] stage: {stage}");

        if (stageParents == null || stageParents.Length <= stage || stageParents[stage] == null)
        {
            Debug.LogError("[StageManager] stageParents가 비었거나 해당 인덱스가 null입니다.");
            return;
        }

        Transform stagePosition = stageParents[stage];
        Transform fireboySpawn = stagePosition.Find("FireboySpawn");
        Transform watergirlSpawn = stagePosition.Find("WatergirlSpawn");

        if (fireboySpawn == null || watergirlSpawn == null)
        {
            Debug.LogError("[StageManager] 스폰 위치를 찾을 수 없습니다.");
            return;
        }

        Debug.Log($"[SpawnCharacters] 위치: Fireboy({fireboySpawn.position}), Watergirl({watergirlSpawn.position})");

        foreach (var player in GameObject.FindGameObjectsWithTag("Player"))
        {
            Destroy(player);
        }

        GameObject fireboy = Instantiate(fireboyPrefab, fireboySpawn.position, Quaternion.identity);
        GameObject watergirl = Instantiate(watergirlPrefab, watergirlSpawn.position, Quaternion.identity);

        Debug.Log($"[SpawnCharacters] 생성 완료: {fireboy.name}, {watergirl.name}");
    }

    public void ToNextStage()
    {
        if (currentStage + 1 < stageParents.Length)
        {
            GameManager.gameManager.SaveStageClear(currentStage);

            currentStage++;
            SpawnCharacters(currentStage);
        }
        else { SceneManagement.sceneManager.ToStartScene(); }
    }
}
