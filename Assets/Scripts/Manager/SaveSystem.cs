using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private const string clearedStageKey = "ClearStage";

    public static void SaveClearedStage(int stageIndex, int stars) // ����
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

    public static int GetClearedStage() // �������� �ҷ�����
    {
        return PlayerPrefs.GetInt("ClearStage", 0);
    }
    public static int GetStars(int stageIndex) // �� �ҷ�����
    {
        string starKey = $"Stage{stageIndex}_Star";
        return PlayerPrefs.GetInt(starKey, 0);
    }
}
