using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDoor_Red : MonoBehaviour
{
    [SerializeField] private GoalDoor_RB_Clear GoalDoor_RB_Clear;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("RedPlayer"))
        {
            GoalDoor_RB_Clear.IsArriveRed();
        }
    }
}
