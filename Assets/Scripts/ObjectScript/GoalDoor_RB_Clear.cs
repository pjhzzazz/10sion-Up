using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDoor_RB_Clear : MonoBehaviour
{
    private bool isArriveRed = false;
    private bool isArriveBlue = false;

    public void IsArriveRed()
    {
        isArriveRed = true;
        BothArriveRB();
    }

    public void IsArriveBlue()
    {
        isArriveBlue = true;
        BothArriveRB();
    }

    private void BothArriveRB()
    {
        if (isArriveRed && isArriveBlue)
        {
            Debug.Log("∞Ò¿Œ!");
            GameManager.gameManager.Success();
        }
    }
}
