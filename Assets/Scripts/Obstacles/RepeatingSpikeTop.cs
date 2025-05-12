using UnityEngine;

public class RepeatingSpikeTop : MonoBehaviour
{
    public float interval = 2f;
    public Rigidbody2D _rigidbody2D;
    private float timer = 0f;
    private bool playerInside = false;

    void Update()
    {
        if (!playerInside) return;

        timer += Time.deltaTime;
        if (timer >= interval)
        {
            SpawnSpike();
            timer = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RedPlayer") || other.CompareTag("BluePlayer"))
        {
            playerInside = true;
            timer = interval; // 입장하자마자 바로 한 번 떨어뜨리기
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("RedPlayer") || other.CompareTag("BluePlayer"))
        {
            playerInside = false;
            timer = 0f;
        }
    }

    void SpawnSpike()
    {
        Instantiate(this, transform.position, Quaternion.identity);
    }
}
