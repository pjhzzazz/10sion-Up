using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLaserButtonTrigger : MonoBehaviour
{
    public LaserManager laserManager;
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
        if (animator == null) Debug.LogError(" Animator가 null입니다!");
        if (laserManager == null) Debug.LogError(" LaserManager가 null입니다!");
        if (other.CompareTag("FirePlayer"))  //Todo 플레이어 타입 Fire
        {
            isTrigger = !isTrigger;
            animator.SetBool("isTrigger", isTrigger);
            laserManager.ToggleRedLasers();
        }
    }
}
