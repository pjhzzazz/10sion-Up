using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableKeyDoor : MonoBehaviour
{
    private GameObject spriteAndCollider;

    void Awake()
    {
        // "SpriteAndCollider" 라는 이름의 자식만 찾아서 캐싱
        spriteAndCollider = transform.Find("lock_yellow")?.gameObject;
        if (spriteAndCollider == null)
            Debug.LogError("자식 'lock_yellow' 를 찾을 수 없습니다.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KeyTrigger") && spriteAndCollider != null && spriteAndCollider.activeSelf)
            spriteAndCollider.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("KeyTrigger") && spriteAndCollider != null && spriteAndCollider.activeSelf)
            spriteAndCollider.SetActive(true);
    }
}