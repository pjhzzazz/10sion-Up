using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player
{
    public enum ControlType { Player1, Player2 }
    public ControlType controlType = ControlType.Player1;

    public float jumpForce = 5f;
    private bool isGrounded = true;
    private bool isJumping = false;



    protected override void HandleAction()
    {
        float vertical = 0f;
        float horizontal = Input.GetAxisRaw("Horizontal");
        movementDirection = new Vector2(horizontal, 0).normalized;

        if (controlType == ControlType.Player1)
        {
            horizontal = (Input.GetKey(KeyCode.D) ? 1 : 0) + (Input.GetKey(KeyCode.A) ? -1 : 0);
            vertical =  (Input.GetKey(KeyCode.S) ? -1 : 0);

            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {

                Jump();
            }
        }
        else if (controlType == ControlType.Player2)
        {
            horizontal = (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) + (Input.GetKey(KeyCode.LeftArrow) ? -1 : 0);
            vertical =(Input.GetKey(KeyCode.DownArrow) ? -1 : 0);

            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                Jump();
            }
        }

        movementDirection = new Vector2(horizontal, vertical).normalized;
    }

    private void Jump()
    {
        if (!isJumping)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
            isJumping = true;
            animationHandler.Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animationHandler.Land();
        }

        foreach (ContactPoint2D contact in collision.contacts)
        {
            // 아래 방향과 충돌면의 노멀을 비교 (노멀.y가 높을수록 아래에서 위로 힘이 작용함)
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                return;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    public override void Death()
    {
        GameManager.gameManager.GameOver();
    }
}
