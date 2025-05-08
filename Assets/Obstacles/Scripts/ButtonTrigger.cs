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
        //�Ķ��� ������ ����
        if(other.CompareTag("Player"))//Todo �÷��̾� Ÿ�� Water
        {
            isTrigger = !isTrigger;
            animator.SetBool("isTrigger", isTrigger);
            obstaclemanager.ToggleBlueLasers();
        }
        //if (other.CompareTag("Player"))  //Todo �÷��̾� Ÿ�� Fire
        //{
        //    isTrigger = !isTrigger;
        //    animator.SetBool("isTrigger", isTrigger);
        //    obstaclemanager.ToggleRedLasers();
        //}
    }
}
