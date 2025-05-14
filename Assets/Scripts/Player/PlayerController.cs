using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player
{
    public enum ControlType { Player1, Player2 }
    public ControlType controlType = ControlType.Player1;

    public float jumpForce = 5f;
    public bool isGrounded = true;
    public bool isJumping = false;



    protected override void HandleAction()
    {
        float horizontal = 0f;

        if (controlType == ControlType.Player1)
        {
            horizontal = (Input.GetKey(KeyCode.D) ? 1 : 0) + (Input.GetKey(KeyCode.A) ? -1 : 0);

            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                Jump();
            }
        }
        else if (controlType == ControlType.Player2)
        {
            horizontal = (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) + (Input.GetKey(KeyCode.LeftArrow) ? -1 : 0);

            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                Jump();
            }
        }

        movementDirection = new Vector2(horizontal, 0f);
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
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (Vector2.Angle(contact.normal, Vector2.up) <= 45f)
                {
                    isGrounded = true;
                    isJumping = false;
                    animationHandler.Land();
                    return;
                }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    public override void Death()
    {
        GameManager.Instance.GameOver();
    }
}
