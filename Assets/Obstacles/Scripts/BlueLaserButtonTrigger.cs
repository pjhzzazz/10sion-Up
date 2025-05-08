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
        //�Ķ��� ������ ����
        if (other.CompareTag("WaterPlayer"))    //Todo �÷��̾� Ÿ�� Water
        {
            isTrigger = !isTrigger;
            animator.SetBool("isTrigger", isTrigger);
            laserManager.ToggleBlueLasers();
        }
    }
}
