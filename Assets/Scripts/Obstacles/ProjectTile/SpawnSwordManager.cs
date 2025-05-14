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

    void SpawnFlyingSword()
    {
        if (flyingSwordPrefab != null)
        {
            Instantiate(flyingSwordPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("FlyingSword ÇÁ¸®ÆÕ ¼Ò½Ç");
        }
    }
}
