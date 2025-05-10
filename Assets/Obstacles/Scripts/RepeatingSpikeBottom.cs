using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RepeatingSpikeBottom : MonoBehaviour
{
    public Rigidbody2D _rigidbody2D;
    public float speed = 4f;
    private void Start()
    {
        _rigidbody2D.gravityScale = 0;
        _rigidbody2D.velocity = Vector2.up * speed;
        
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
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
