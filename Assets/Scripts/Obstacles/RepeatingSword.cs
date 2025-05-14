using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingSword : MonoBehaviour
{
    public float speed = 8.0f;
    public Vector2 direction = Vector2.right;
    void Start()
    {

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //x, y 벡터 방향으로의 각도를 라디안으로 계산
        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);//Z축을 기준으로 angle만큼 회전된 회전값을 반환 칼이 세워져있어서 -90
    }


    void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World); //지정한 방향으로, 초당 speed만큼, 월드 기준으로 이동

        if (transform.position.x < 15f)  
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RedPlayer") || collision.gameObject.CompareTag("BluePlayer"))
        {
            GameManager.Instance.GameOver();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
