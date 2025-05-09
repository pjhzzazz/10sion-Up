using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRed : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RedPlayer"))
        {
            //GameManager.Instance.AddScore(1);
            //PlusGemScore(); 같은걸로?

            Destroy(gameObject);
        }
    }
}
