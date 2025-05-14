using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatSnowBall : MonoBehaviour
{
    public float lifeSpan = 4.5f;

    void Start()
    {

        Destroy(gameObject, lifeSpan);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RedPlayer") || collision.gameObject.CompareTag("BluePlayer"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
