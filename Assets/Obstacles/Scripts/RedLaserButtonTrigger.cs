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
        if (animator == null) Debug.LogError(" Animator�� null�Դϴ�!");
        if (laserManager == null) Debug.LogError(" LaserManager�� null�Դϴ�!");
        if (other.CompareTag("FirePlayer"))  //Todo �÷��̾� Ÿ�� Fire
        {
            isTrigger = !isTrigger;
            animator.SetBool("isTrigger", isTrigger);
            laserManager.ToggleRedLasers();
        }
    }
}
