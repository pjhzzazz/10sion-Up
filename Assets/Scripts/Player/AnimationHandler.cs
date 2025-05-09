using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsDie = Animator.StringToHash("IsDie");
    private static readonly int IsJump = Animator.StringToHash("IsJump");

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        animator.SetBool(IsMoving, obj.magnitude > .5f);
    }

    public void Die()
    {
        animator.SetBool(IsDie, true);
    }

    public void Jump()
    {
        animator.SetBool(IsJump, true);
    }

    public void InvincibilityEnd()
    {
        animator.SetBool(IsDie, false);
    }
}
