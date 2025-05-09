using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private const string clearedStageKey = "ClearStage";

    public static void SaveClearedStage(int stageIndex) // ����
    {
        if (stageIndex > GetClearedStage())
        {
            PlayerPrefs.SetInt("ClearStage", stageIndex);
            PlayerPrefs.Save();
        }
    }

    public static int GetClearedStage() // �ҷ�����
    {
        return PlayerPrefs.GetInt("ClearStage", 0);
    }
}
