using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLaserButtonTrigger : MonoBehaviour
{
    public RedLaser[] redLasers;
    private Animator animator;
    private bool isTrigger = false;
    // Start is called before the first frame update
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
       
        if (other.CompareTag("RedPlayer"))  
        {
            isTrigger = !isTrigger;
            animator.SetBool("isTrigger", isTrigger); // ����ġ �ִϸ��̼� �۵�
            for (int i = 0; i < redLasers.Length; i++)
            {
                redLasers[i].ToggleRedLaser();     //������ ������ ����
            }
        }
    }
}
