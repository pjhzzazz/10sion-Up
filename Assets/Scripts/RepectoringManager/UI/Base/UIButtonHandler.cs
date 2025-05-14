using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonHandler : MonoBehaviour
{
    public static void OnStageSelectAndRestartButtonClicked(int selectedStage)
    {
        AudioManager.Instance.PlaySoundEffects("click");
        GameManager.Instance.StartGame(selectedStage);
    }


    public static void OnMainMenuButtonClicked()
    {
        AudioManager.Instance.PlaySoundEffects("click");
        GameManager.Instance.ReturnToSelectingStage();
    }
}
