using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangShield : MonoBehaviour
{
    public float distance = 3f;           // 이동 거리
    public float speed = 2f;              // 이동 속도
    public float spinSpeed = 600f;        // 회전 속도 (도/초)

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool go = true;
    private bool back = false;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + transform.right * distance;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);


        if (go)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPos) < 0.01f) // 타겟 위치에 도착시
            {
                go = false;
                back = true;
            }
        }
        else if (back)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
            if(Vector3.Distance(transform.position, startPos) < 0.01f) // 처음 위치에 도착시
            {
                go = true;
                back = false;
            }
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RedPlayer") || collision.gameObject.CompareTag("BluePlayer"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
