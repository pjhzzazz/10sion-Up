using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLaserButtonTrigger : MonoBehaviour
{
    public RedLaser[] redLasers;
    private Animator animator;
    private bool isTrigger = false;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RedPlayer"))  
        {
            isTrigger = !isTrigger;
            animator.SetBool("isTrigger", isTrigger); // 스위치 애니메이션 작동
            for (int i = 0; i < redLasers.Length; i++)
            {
                redLasers[i].ToggleRedLaser();     //빨간색 레이저 제어
            }
        }
    }
}

