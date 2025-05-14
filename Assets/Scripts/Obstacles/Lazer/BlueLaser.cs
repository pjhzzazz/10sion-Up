using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLaser : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RedPlayer"))
        {
            GameManager.Instance.GameOver();
        }
    }

    public void ToggleBlueLaser()
    {
          gameObject.SetActive(!gameObject.activeSelf); 
    }
}