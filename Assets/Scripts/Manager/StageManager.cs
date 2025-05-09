using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{

    [Header("ĳ���� ������")]
    public GameObject fireboyPrefab;
    public GameObject watergirlPrefab;

    [Header("�������� �߰�")]
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
            Debug.LogError("[StageManager] stageParents�� ����ų� �ش� �ε����� null�Դϴ�.");
            return;
        }

        Transform stagePosition = stageParents[stage];
        Transform fireboySpawn = stagePosition.Find("FireboySpawn");
        Transform watergirlSpawn = stagePosition.Find("WatergirlSpawn");

        if (fireboySpawn == null || watergirlSpawn == null)
        {
            Debug.LogError("[StageManager] ���� ��ġ�� ã�� �� �����ϴ�.");
            return;
        }

        Debug.Log($"[SpawnCharacters] ��ġ: Fireboy({fireboySpawn.position}), Watergirl({watergirlSpawn.position})");

        foreach (var player in GameObject.FindGameObjectsWithTag("Player"))
        {
            Destroy(player);
        }

        GameObject fireboy = Instantiate(fireboyPrefab, fireboySpawn.position, Quaternion.identity);
        GameObject watergirl = Instantiate(watergirlPrefab, watergirlSpawn.position, Quaternion.identity);

        Debug.Log($"[SpawnCharacters] ���� �Ϸ�: {fireboy.name}, {watergirl.name}");
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
