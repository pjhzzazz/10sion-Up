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
        // Rigidbody2D 컴포넌트를 캐싱
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 1) 화살표 키 입력 받아서 movement 벡터에 저장
        movement.x = 0;
        movement.y = 0;

        if (Input.GetKey(KeyCode.RightArrow)) movement.x = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) movement.x = -1;
        if (Input.GetKey(KeyCode.UpArrow)) movement.y = 1;
        if (Input.GetKey(KeyCode.DownArrow)) movement.y = -1;

        // 대각선 이동 시 속도가 sqrt(2)배 빨라지는 걸 방지
        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        // 2) 물리 업데이트에서 속도 적용
        _rigidbody.velocity = movement * Speed;
    }
}
