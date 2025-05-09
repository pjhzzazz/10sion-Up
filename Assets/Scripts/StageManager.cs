using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager stageManager{ get; private set; }

    [Header("캐릭터 프리팹")]
    public GameObject fireboyPrefab;
    public GameObject watergirlPrefab;

    [Header("스테이지 추가")]
    public Transform[] stageParents;
    public int currentStage;

    private void Awake()
    {
        if (stageManager != null)
        {
            Destroy(gameObject);
            return;
        }
        stageManager = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        SpawnCharacters(currentStage);
    }

    public void SpawnCharacters(int stageIndex)
    {
        Transform stage = stageParents[stageIndex];

        Transform fireboySpawn = stage.Find("FireboySpawn");
        Transform watergirlSpawn = stage.Find("WatergirlSpawn");

        foreach (var player in GameObject.FindGameObjectsWithTag("Player")) // 중복 생성 방지용
        {
            Destroy(player);
        }

        Instantiate(fireboyPrefab, fireboySpawn.position, Quaternion.identity);
        Instantiate(watergirlPrefab, watergirlSpawn.position, Quaternion.identity);
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
