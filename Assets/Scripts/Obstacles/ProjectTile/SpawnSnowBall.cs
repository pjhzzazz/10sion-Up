using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnowBall : MonoBehaviour
{
    public GameObject snowBallPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 2f;
    void Start()
    {
        InvokeRepeating("SpawnSnow", spawnInterval, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnSnow()
    {
        Instantiate(snowBallPrefab, spawnPoint.position, Quaternion.identity);
    }
}
