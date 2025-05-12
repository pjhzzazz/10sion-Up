using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingRock : MonoBehaviour
{
    public Rigidbody2D _rigidody2D;
    public float lifeSpan = 4.5f;

    void Start()
    {
        _rigidody2D.simulated = false;
        Invoke("Rolling", 2f);

        Destroy(gameObject, lifeSpan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Rolling()
    {
        _rigidody2D.simulated = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("RedPlayer") || collision.gameObject.CompareTag("BluePlayer"))
        {
            Destroy(collision.gameObject);
        }
    }
}
