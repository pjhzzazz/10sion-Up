using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;
    public Rigidbody2D _rigidbody;
    public Vector2 movement;

    void Awake()
    {
        // Rigidbody2D ������Ʈ�� ĳ��
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 1) ȭ��ǥ Ű �Է� �޾Ƽ� movement ���Ϳ� ����
        movement.x = 0;
        movement.y = 0;

        if (Input.GetKey(KeyCode.RightArrow)) movement.x = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) movement.x = -1;
        if (Input.GetKey(KeyCode.UpArrow)) movement.y = 1;
        if (Input.GetKey(KeyCode.DownArrow)) movement.y = -1;

        // �밢�� �̵� �� �ӵ��� sqrt(2)�� �������� �� ����
        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        // 2) ���� ������Ʈ���� �ӵ� ����
        _rigidbody.velocity = movement * Speed;
    }
}
