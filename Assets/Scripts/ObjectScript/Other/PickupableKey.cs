using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableKey : MonoBehaviour
{
    Transform originalParent;

    void Awake()
    {
        originalParent = transform.parent;
    }

    public void PickUp(Transform holdPoint)
    {
        transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
        PlayerKeyPickUp.isHeld = true;
    }

    public void Drop()
    {
        transform.SetParent(originalParent);
        PlayerKeyPickUp.isHeld = false;
    }
}
