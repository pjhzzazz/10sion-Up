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
        // Case 2: RedDeadZone은 FirePlayer만
        else if (layer == LayerMask.NameToLayer("RedDeadZone"))
        {
            if (tag == "RedPlayer")
            {
                HandleDeath(collision);
            }
        }
        // Case 3: BlueDeadZone은 WaterPlayer만
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

        // 예: 초기 위치로 리스폰
        collision.transform.position = new Vector3(0, 0, 0);

        // 또는 Die() 메서드가 있다면 실행
        // var player = collision.GetComponent<Player>();
        // if (player != null) player.Die();
    }
}
