using System.Collections;
using System.Collections.Generic;
// GoalDoor.cs
using UnityEngine;

public class GoalDoor : MonoBehaviour
{
    [SerializeField] private Collider2D GoalCollider;

    //문오브젝트
    [SerializeField] private GameObject DoorTop;
    [SerializeField] private GameObject DoorBot;
    //문 위에 플레이어 어떤 색이 도착해있는지 확인하는 표시 오브젝트
    [SerializeField] private GameObject GoalRed;
    [SerializeField] private GameObject GoalBlue;
    //문 도착한 플레이어 비활성화를 위한 오브젝트 - 플레이어 끌어오기
    [SerializeField] private GameObject PlayerRed;
    [SerializeField] private GameObject PlayerBlue;


    //키 획득 상태
    private bool hasRedKey = false;
    private bool hasBlueKey = false;

    //문 열리고 플레이어 도착 상태
    private bool IsRedGoal = false;
    private bool IsBlueGoal = false;

    private void Start()
    {
        GoalCollider.enabled = false;
    }

    //열쇠 스크립트에서 호출할 메서드들
    public void CollectRedKey()
    {
        hasRedKey = true;
        CheckBothKeys();
    }

    public void CollectBlueKey()
    {
        hasBlueKey = true;
        CheckBothKeys();
    }

    // 빨간 열쇠, 파란 열쇠 둘다 주웠는지 검사
    private void CheckBothKeys()
    {
        if (hasRedKey && hasBlueKey)
            OpenGoalDoor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WaterPlayer"))
        {
            IsBlueGoal = true;
            //파란 플레이어 사라지게
            PlayerBlue.SetActive(false);
        }
        if (collision.gameObject.CompareTag("FirePlayer"))
        {
            IsRedGoal = true;
            //빨간 플레이어 사라지게
            PlayerRed.SetActive(false);
        }
    }

    private void OpenGoalDoor()
    {
        DoorTop.SetActive(false);
        DoorBot.SetActive(false);
        GoalCollider.enabled = true;
        Debug.Log("골인지점 문 열림!");
        if (IsBlueGoal)
        {
            GoalBlue.SetActive(true);
        }
        if (IsRedGoal)
        {
            GoalRed.SetActive(true);
        }
        if (IsBlueGoal || IsRedGoal)
        {
            //게임클리어 및 씬 종료
        }
    }
}
