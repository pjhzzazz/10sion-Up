using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRatingUI : MonoBehaviour
{
    public static StarRatingUI Instance;

    [Header("별")]
    public GameObject[] starObjects;

    public int stars = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
    }

    public void PointToStar(float gainedGem, float takingTime) //점수를 별로 계산
    {
        float jewelRate = gainedGem / 10;
        float timeRate = 40 / takingTime;
        timeRate = Mathf.Min(timeRate, 1f);

        float point = jewelRate * 0.5f + timeRate * 0.5f;

        if (point > 0.8f) stars = 5;
        else if (point > 0.6f) stars = 4;
        else if (point > 0.4f) stars = 3;
        else if (point > 0.2f) stars = 2;
        else stars = 1;

        ShowStarsUI(starObjects, stars);
    }

    public void ShowStarsUI(GameObject[] starObjects, int stars) // 별 UI 나타내기
    {
        for (int i = 0; i < starObjects.Length; i++)
        {
            Transform emptyStar = starObjects[i].transform.Find("EmptyStar");
            Transform fullStar = starObjects[i].transform.Find($"Star");

            bool isShowStar = i < stars;
            {
                emptyStar.gameObject.SetActive(!isShowStar);
                fullStar.gameObject.SetActive(isShowStar);
            }
        }
    }
}
