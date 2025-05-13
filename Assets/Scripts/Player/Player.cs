using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerType { Fire, Water }
    public PlayerType playerType;

    protected Rigidbody2D _rigidbody;
    protected AnimationHandler animationHandler;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        if (GameManager.gameManager.IsPaused)
            return;

        if (transform.position.y < -6f)
        {
            Death();
            return;
        }

        HandleAction();

    }
    
    protected virtual void FixedUpdate()
    {
        if (GameManager.gameManager.IsPaused)
            return;
        Movment(movementDirection);
    }
  
    protected virtual void HandleAction()
    {

    }

    private void Movment(Vector2 direction)
    {
        direction = new Vector2(direction.x * 5f, _rigidbody.velocity.y);
        _rigidbody.velocity = direction;
        animationHandler.Move(direction);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerType == PlayerType.Fire)
        {
            if (collision.CompareTag("Water"))
            {
                animationHandler.Die();
                GameManager.gameManager.GameOver();
            }
            else if (collision.CompareTag("Fire"))
            {
                // 통과 허용 또는 무시
            }
        }
        else if (playerType == PlayerType.Water)
        {
            if (collision.CompareTag("Water"))
            {
                // 통과 허용 또는 무시
            }
            else if (collision.CompareTag("Fire"))
            {
                animationHandler.Die();
                GameManager.gameManager.GameOver();
            }
        }
    }

    public virtual void Death()
    {

    }
}
