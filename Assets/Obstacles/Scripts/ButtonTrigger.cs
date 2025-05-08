using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public ObstacleManager obstaclemanager;
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
        if(other.CompareTag("Player"))//Todo 플레이어 타입 Water
        {
            isTrigger = !isTrigger;
            animator.SetBool("isTrigger", isTrigger);
            obstaclemanager.ToggleBlueLasers();
        }
        //if (other.CompareTag("Player"))  //Todo 플레이어 타입 Fire
        //{
        //    isTrigger = !isTrigger;
        //    animator.SetBool("isTrigger", isTrigger);
        //    obstaclemanager.ToggleRedLasers();
        //}
    }
}
