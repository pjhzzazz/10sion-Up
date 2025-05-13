using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableKeyDoor : MonoBehaviour
{
    [SerializeField] GameObject spriteAndCollider;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            spriteAndCollider.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            spriteAndCollider.SetActive(true);
        }
    }
}
