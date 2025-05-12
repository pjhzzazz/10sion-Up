using UnityEngine;

public class RepeatingSpikeTop : MonoBehaviour
{
    private float spawnTime;

    private void Start()
    {
        spawnTime = Time.time;  
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RedPlayer") || collision.gameObject.CompareTag("BluePlayer"))
        {
            Destroy(collision.gameObject);
        }
        else if (Time.time - spawnTime > 0.5f && collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

}
