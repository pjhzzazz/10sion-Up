using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLaserButtonTrigger : MonoBehaviour
{
    public BlueLaser[] blueLasers;
    private Animator animator;
    private bool isTrigger = false;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //파란색 레이저 제어
        if (other.CompareTag("BluePlayer"))    
        {
            isTrigger = !isTrigger;
            animator.SetBool("isTrigger", isTrigger);//스위치 애니메이션 작동
            for (int i = 0; i < blueLasers.Length; i++)
            {
                blueLasers[i].ToggleBlueLaser();//파란색 레이저 제어
            }
        }
    }
}
