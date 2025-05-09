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

    //private float minY = -4.6f;

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
    /*
    void LateUpdate()
    {
        if (transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0f);
        }
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerType == PlayerType.Fire)
        {
            if (collision.CompareTag("Ice"))
            {
                Destroy(collision.gameObject); // 얼음 파괴
            }
            else if (collision.CompareTag("FireObstacle"))
            {
                // 통과 허용 또는 무시
            }
        }
        else if (playerType == PlayerType.Water)
        {
            if (collision.CompareTag("WaterObstacle"))
            {
                // 통과 허용 또는 무시
            }
            else if (collision.CompareTag("Fire"))
            {
                Destroy(collision.gameObject); // 불 파괴
            }
        }
    }
}
