using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailureUI : BaseUI
{
    [Header("Buttons")]
    [SerializeField] private Button retryBtn;
    [SerializeField] private Button EndBtn;

    private void Awake()
    {
        retryBtn.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlaySoundEffects("click");
            UIButtonHandler.OnStageSelectAndRestartButtonClicked(GameManager.Instance.selectedStage);
            Hide();
        });

        EndBtn.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlaySoundEffects("click");
            UIButtonHandler.OnMainMenuButtonClicked();
            Hide();
        });
    }
}
