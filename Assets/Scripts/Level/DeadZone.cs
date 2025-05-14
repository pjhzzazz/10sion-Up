using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;
        int layer = gameObject.layer;

        // Case 1: 공통 DeadZone
        if (layer == LayerMask.NameToLayer("DeadZone"))
        {
            if (tag == "RedPlayer" || tag == "BluePlayer")
            {
                HandleDeath(collision);
            }
        }
        // Case 2: RedDeadZone은 RedPlayer만
        else if (layer == LayerMask.NameToLayer("RedDeadZone"))
        {
            if (tag == "RedPlayer")
            {
                HandleDeath(collision);
            }
        }
        // Case 3: BlueDeadZone은 BluePlayer만
        else if (layer == LayerMask.NameToLayer("BlueDeadZone"))
        {
            if (tag == "BluePlayer")
            {
                HandleDeath(collision);
            }
        }
    }

    private void HandleDeath(Collider2D collision)
    {
        Debug.Log($"{collision.tag} 가 {LayerMask.LayerToName(gameObject.layer)}에 충돌했습니다.");

        // 캐릭터 사망 메서드
        GameManager.Instance.GameOver();

    }
}
