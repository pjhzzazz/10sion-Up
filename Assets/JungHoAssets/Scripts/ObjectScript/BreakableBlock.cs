using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour
{
    [SerializeField] private GameObject[] cracks; //0~2 인덱스로 Crack1, Crack2, Crack3

    private bool isBreaking = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //한번만 실행되도록 플래그 체크
        if (!isBreaking)
        {
            isBreaking = true;
            //Update문이 아닌곳에서 반복문은 StartCoroutine 쓰면 된다함
            StartCoroutine(BreakSequence());
        }
    }

    private IEnumerator BreakSequence()
    {
        //1초 간격으로 cracks 배열의 요소를 순서대로 활성화
        for (int i = 0; i < cracks.Length; i++)
        {
            if (cracks[i] != null)
                cracks[i].SetActive(true);
            //1초후 반복
            yield return new WaitForSeconds(1f);
        }

        //세 번 다 활성화된 후 한 번 더 대기(추가로 1초를 더 두고 싶으면)
        //yield return new WaitForSeconds(1f);

        //블록 삭제
        Destroy(gameObject);
    }
}
