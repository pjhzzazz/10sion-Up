using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlockDestroy : MonoBehaviour
{
    // RedBlock 레이어와 BlueBlock 레이어의 번호를 Inspector에서 설정할 수도 있음
    public LayerMask redBlockLayer;
    public LayerMask blueBlockLayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string otherTag = collision.gameObject.tag;
        int thisLayer = gameObject.layer;

        // Case 1: RedPlayer가 RedBlock에 충돌
        if (otherTag == "RedPlayer" && thisLayer == LayerMask.NameToLayer("RedBlock"))
        {
            Debug.Log("RedPlayer와 RedBlock 충돌! 오브젝트 파괴");
            Destroy(gameObject);
        }
        // Case 2: BluePlayer가 BlueBlock에 충돌
        else if (otherTag == "BluePlayer" && thisLayer == LayerMask.NameToLayer("BlueBlock"))
        {
           Debug.Log("BluePlayer와 BlueBlock 충돌! 오브젝트 파괴");
            Destroy(gameObject);
        }
        // 그 외 조합은 아무 일도 하지 않음 → 충돌 판정 유지
        else
        {
            //Debug.Log("다른 조합 - 충돌 유지 (밟을 수 있음)");
        }
    }
}
