using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PressurePlateActiveBlock : MonoBehaviour
{
    public enum PlateColor
    {
        Yellow,
        Green,
        Red,
        Blue
    }

    public PlateColor DoorColor;

    private Animator animator;
    private Collider2D doorCollider;
    private bool isOpen = false;

    public void Open()
    {
        if (isOpen) return;
        isOpen = true;
        animator?.SetTrigger("Open");
        if (doorCollider != null) doorCollider.enabled = false;
    }

    public void Close()
    {
        if (!isOpen) return;
        isOpen = false;
        animator?.SetTrigger("Close");
        if (doorCollider != null) doorCollider.enabled = true;
    }
}
