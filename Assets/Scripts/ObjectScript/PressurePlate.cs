using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public enum PlateColor
    {
        Yellow,
        Green,
        Red,
        Blue
    }

    public PlateColor SelectedPlateColor;

    private void OnCollisionStay2D(Collision2D collision)
    {
        ActivateBlock(SelectedPlateColor);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        DeActivateBlock(SelectedPlateColor);
    }

    void ActivateBlock(PlateColor color)
    {
        var door = GameObject.FindWithTag(color.ToString() + "Door");
        if (door != null)
        {
            door.GetComponent<PressurePlateActiveBlock>().Open();
        }
    }

    void DeActivateBlock(PlateColor color)
    {
        var door = GameObject.FindWithTag(color.ToString() + "Door");
        if (door != null)
        {
            door.GetComponent<PressurePlateActiveBlock>().Close();
        }
    }
}
