using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDoorKeyRed : MonoBehaviour
{
    [SerializeField] private GoalDoor goalDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FirePlayer"))
        {
            goalDoor.CollectRedKey();
            Destroy(gameObject);
        }
    }
}