using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RepeatingSpike : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if ( collision.gameObject.CompareTag("RedPlayer") )
        {
            GameManager.Instance.GameOver();
        }

        if (collision.gameObject.CompareTag("BluePlayer"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
