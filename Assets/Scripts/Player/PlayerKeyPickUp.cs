using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerKeyPickUp : MonoBehaviour
{
    [Header("줍기/내리기 키")]
    [SerializeField] KeyCode pickKey = KeyCode.E;

    [Tooltip("키를 붙일 빈 자식 오브젝트")]
    [SerializeField] Transform holdPoint;

    PickupableKey heldKey = null;

    bool isInArea = false;

    void Update()
    {
        if (Input.GetKeyDown(pickKey) && isInArea)
        {
            if (heldKey == null)
                TryPickUp();
            else
                DropKey();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            isInArea = true;
            heldKey = collision.GetComponent<PickupableKey>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            isInArea = false;
            if (heldKey != null && heldKey.gameObject == collision.gameObject)
            {
                heldKey = null;
            }
        }
    }

    void TryPickUp()
    {
        if (heldKey != null)
        {
            heldKey.PickUp(holdPoint);
            return;
        }
    }

    void DropKey()
    {
        heldKey.Drop();
        heldKey = null;
    }
}
