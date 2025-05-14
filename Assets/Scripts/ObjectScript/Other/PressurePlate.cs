using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private Animator animator;

    //색깔 고르기(이미 프리팹 마다 정해져서 다 들어가 있음)
    public PressurePlateActiveBlock.PlateColor SelectedPlateColor;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("KeyTrigger"))
        {
            animator?.SetBool("isPress", true);
            SetDoorState(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("KeyTrigger"))
        {
            animator?.SetBool("isPress", false);
            SetDoorState(false);
        }
    }

    private void SetDoorState(bool open)
    {
        //활성화되는 블록 불러오기
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
