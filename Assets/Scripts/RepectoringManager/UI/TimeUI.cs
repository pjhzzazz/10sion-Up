using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeTxt;

    private void Update()
    {
        if (GameManager.Instance.CurrentState == GameManager.GameState.Playing)
        {
            float playTime = GameManager.Instance.playTime;
            int minutes = Mathf.FloorToInt(playTime / 60f);
            int seconds = Mathf.FloorToInt(playTime % 60f);
            timeTxt.text = $"{minutes:D2}:{seconds:D2}";
        }
    }
}
