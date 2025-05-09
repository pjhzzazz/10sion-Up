using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLaser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BluePlayer"))
        {
            Debug.Log("WaterPlayer°¡ Á×À½");
           
        }
    }


    public void ToggleRedLaser()
    {
            gameObject.SetActive(!gameObject.activeSelf);
    }
}
