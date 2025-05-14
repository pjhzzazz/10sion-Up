using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDoor_Blue : MonoBehaviour
{
    [SerializeField] private GoalDoor_RB_Clear GoalDoor_RB_Clear;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("BluePlayer"))
        {
            GoalDoor_RB_Clear.IsArriveBlue();
        }
    }
}
