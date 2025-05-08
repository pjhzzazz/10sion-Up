using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player
{
    public enum ControlType { Player1, Player2 }
    public ControlType controlType = ControlType.Player1;

    public float jumpForce = 5f;
    private bool isGrounded = true; // 바닥에 있을 때만 점프 가능

    protected override void HandleAction()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (controlType == ControlType.Player1)
        {
            horizontal = (Input.GetKey(KeyCode.D) ? 1 : 0) + (Input.GetKey(KeyCode.A) ? -1 : 0);
            vertical = (Input.GetKey(KeyCode.W) ? 1 : 0) + (Input.GetKey(KeyCode.S) ? -1 : 0);

            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                Jump();
            }
        }
        else if (controlType == ControlType.Player2)
        {
            horizontal = (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) + (Input.GetKey(KeyCode.LeftArrow) ? -1 : 0);
            vertical = (Input.GetKey(KeyCode.UpArrow) ? 1 : 0) + (Input.GetKey(KeyCode.DownArrow) ? -1 : 0);

            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                Jump();
            }
        }

        movementDirection = new Vector2(horizontal, vertical).normalized;
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 바닥에 닿았을 때 다시 점프 가능하게 함
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

}
