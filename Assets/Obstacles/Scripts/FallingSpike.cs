using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    private bool dropped = false;
    public Rigidbody2D _rigidbody2D;
    public float delay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!dropped && (collision.gameObject.CompareTag("FirePlayer") || collision.gameObject.CompareTag("WaterPlayer")))
        {
            StartCoroutine(DelayDrop());
        }
        
    }

    IEnumerator DelayDrop()
    {
        yield return new WaitForSeconds(delay);
        _rigidbody2D.gravityScale = 1f;
        dropped = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("FirePlayer") || collision.gameObject.CompareTag("WaterPlayer"))
        {
            Destroy(collision.gameObject); // 플레이어 사망
        }
        else
        {
            Destroy(gameObject);
        }
           
    }
}
