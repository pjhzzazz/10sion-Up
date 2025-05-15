using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSwordManager : MonoBehaviour
{
    public GameObject flyingSwordPrefab;  
    public Transform spawnPoint;           
    public float spawnInterval = 4f;      

    void Start()
    {

        InvokeRepeating("SpawnFlyingSword", spawnInterval, spawnInterval);
    }
    private void OnDisable()
    {
        CancelInvoke("SpawnFlyingSword"); //비활성화되면 자동으로 반복 중단
    }
    void SpawnFlyingSword()
    {
        if (flyingSwordPrefab != null)
        {
            Instantiate(flyingSwordPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("FlyingSword 프리팹 소실");
        }
    }
}
