using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBlue : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BluePlayer"))
        {
            GameManager.Instance.AddGem(1);
            Destroy(gameObject);
        }
    }
}
