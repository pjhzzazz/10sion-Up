using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDoorKeyBlue : MonoBehaviour
{
    [SerializeField] private GoalDoor goalDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterPlayer"))
        {
            goalDoor.CollectBlueKey();
            Destroy(gameObject);
        }
    }
}