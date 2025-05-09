using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    protected AnimationHandler animationHandler;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    private float minY = -4.6f;

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
        HandleAction();
    }
    
    protected virtual void FixedUpdate()
    {
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

    void LateUpdate()
    {
        if (transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0f); // 중력 제거
        }
    }
}
