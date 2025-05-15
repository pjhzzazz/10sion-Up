using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoryUI : BaseUI, IPointerClickHandler
{
    public GameObject[] objects;
    private int currentIndex = 0;

    void Start()
    {

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(i == 0);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        objects[currentIndex].SetActive(false);

        currentIndex++;
        if (currentIndex >= objects.Length)
        {
            GameManager.Instance.ReturnToSelectingStage();
            return; //  뒤에 SetActive(true) 안 하도록 빠져나오기
        }
        objects[currentIndex].SetActive(true);
    }
}
