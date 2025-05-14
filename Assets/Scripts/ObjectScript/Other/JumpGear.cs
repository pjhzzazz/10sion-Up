using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGear : MonoBehaviour
{
    public float jumpForce = 15f; // 점프 힘 설정

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        // RedPlayer 또는 BluePlayer 태그일 때만 작동
        if (tag != "RedPlayer" && tag != "BluePlayer") return;

        // Rigidbody2D 가져오기
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // Y축 속도 초기화 후 위로 힘 가하기
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            Debug.Log($"JumpGear 작동: {tag} 위로 점프!");
        }
    }
}