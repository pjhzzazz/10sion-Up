using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public PressurePlateActiveBlock.PlateColor SelectedPlateColor;
    private void OnTriggerStay2D(Collider2D collision)
    {
        animator?.SetBool("isPress", true);
        SetDoorState(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator?.SetBool("isPress", false);
        SetDoorState(false);
    }

    private void SetDoorState(bool open)
    {
        foreach (var door in FindObjectsOfType<PressurePlateActiveBlock>())
        {
            if (door.DoorColor == SelectedPlateColor)
            {
                if (open)
                    door.Open();
                else
                    door.Close();
            }
        }
    }
}
