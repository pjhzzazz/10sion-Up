using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLaserButtonTrigger : MonoBehaviour
{
    public LaserManager laserManager;
    private Animator animator;
    private bool isTrigger = false;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //파란색 레이저 제어
        if (other.CompareTag("WaterPlayer"))    //Todo 플레이어 타입 Water
        {
            isTrigger = !isTrigger;
            animator.SetBool("isTrigger", isTrigger);
            laserManager.ToggleBlueLasers();
        }
    }
}
