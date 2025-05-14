using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    public static StageController Instance {  get; private set; }

    [Header("캐릭터 프리팹")]
    public GameObject RedPlayerPrefab;
    public GameObject BluePlayerPrefab;

    [Header("스테이지 추가")]
    public GameObject[] stageParents;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
    }

    public void ChangeStage(int selectedStage) // 스테이지 전환
    {
        for (int i = 0; i < stageParents.Length; i++)
        {
            bool isActive = (i == selectedStage);

            if (isActive) stageParents[i].SetActive(true);
            else stageParents[i].SetActive(false);
        }

        SpawnCharacters(selectedStage);
    }

    public void SpawnCharacters(int selectedStage) // 캐릭터 스폰
    {
        Transform stagePosition = stageParents[selectedStage].transform;
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

    public void ToNextStage(int nextStageIndex) //다음 스테이지 전환
    {
        if (nextStageIndex < stageParents.Length)
        {
            ChangeStage(nextStageIndex);
        }
        else
        {
            GameManager.Instance.ReturnToSelectingStage();
        }
    }
}
