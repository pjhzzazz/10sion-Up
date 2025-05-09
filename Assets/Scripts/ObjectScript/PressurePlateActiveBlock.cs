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
    //색 목록중에서 색깔 고르기
    public PlateColor DoorColor;

    [SerializeField] private Animator animator;
    [SerializeField] private Collider2D doorCollider;

    private bool isOpen = false;

    public void Open()
    {
        if (isOpen) return;
        isOpen = true;
        animator?.SetBool("isOpen", true);
        if (doorCollider != null) doorCollider.enabled = false;
    }

    public void Close()
    {
        if (!isOpen) return;
        isOpen = false;
        animator?.SetBool("isOpen", false);
        if (doorCollider != null) doorCollider.enabled = true;
    }
}
