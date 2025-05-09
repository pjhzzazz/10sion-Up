using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private const string clearedStageKey = "ClearStage";

    public static void SaveClearedStage(int stage)
    {
        if (stage > GetClearedStage()) // �� ���� �������� ����
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
