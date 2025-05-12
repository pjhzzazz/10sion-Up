using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private const string clearedStageKey = "ClearStage";

    public static void SaveClearedStage(int stageIndex, int stars) // 저장
    {
        if (stageIndex > GetClearedStage())
        {
            PlayerPrefs.SetInt("ClearStage", stageIndex);
            PlayerPrefs.Save();
        }

        if (stars > GetStars(stageIndex))
        {
            string starKey = $"Stage{stageIndex}_Star";
            PlayerPrefs.SetInt(starKey, stars);
            PlayerPrefs.Save();
        }
    }

    public static int GetClearedStage() // 스테이지 불러오기
    {
        return PlayerPrefs.GetInt("ClearStage", 0);
    }
    public static int GetStars(int stageIndex) // 별 불러오기
    {
        string starKey = $"Stage{stageIndex}_Star";
        return PlayerPrefs.GetInt(starKey, 0);
    }
}
