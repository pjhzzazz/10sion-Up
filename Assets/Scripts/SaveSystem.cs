using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private const string clearedStageKey = "ClearStage";

    public static void SaveClearedStage(int stage)
    {
        if (stage > GetClearedStage()) // 더 높은 스테이지 저장
        {
            PlayerPrefs.SetInt("ClearStage", stage);
            PlayerPrefs.Save();
        }
    }

    public static int GetClearedStage()
    {
        return PlayerPrefs.GetInt("ClearStage", - 1);
    }
}
