using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonHandler : MonoBehaviour
{
    public static void OnStageSelectAndRestartButtonClicked(int selectedStage) => GameManager.Instance.StartGame(selectedStage);

    public static void OnMainMenuButtonClicked() => GameManager.Instance.ReturnToSelectingStage();

}
