using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableKey : MonoBehaviour
{
    Collider2D col;
    Transform originalParent;

    void Awake()
    {
        col = GetComponent<Collider2D>();
        originalParent = transform.parent;
    }

    public void PickUp(Transform holdPoint)
    {
        col.enabled = false;
        transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
    }

    public void Drop()
    {
        transform.SetParent(originalParent);
        col.enabled = true;
    }
}
