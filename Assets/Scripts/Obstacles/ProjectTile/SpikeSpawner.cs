using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    public float interval = 3.5f;
    public GameObject spikeTopPrefab;
    public GameObject spikeBottomPrefab;
    public Transform topSpawnPoint;
    public Transform bottomSpawnPoint;

    private void Start()
    {
        InvokeRepeating("SpawnSpike", interval, interval);
    }

    private void OnDisable()
    {
        CancelInvoke("SpawnSpike"); //비활성화되면 자동으로 반복 중단
    }
    void SpawnSpike()
    {
       
            Instantiate(spikeTopPrefab, topSpawnPoint.position, Quaternion.identity);
     

        
            Instantiate(spikeBottomPrefab, bottomSpawnPoint.position, Quaternion.identity);
     
    }
}
