using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionUI : BaseUI
{
    [Header("Buttons")]
    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button retryBtn;
    [SerializeField] private Button mainMenuBtn;

    private void Awake()
    {
        resumeBtn.onClick.AddListener(() => 
        {
            AudioManager.Instance.PlaySoundEffects("click");
            GameManager.Instance.ResumeGame();
            Hide();
        });

        retryBtn.onClick.AddListener(() => 
        {
            AudioManager.Instance.PlaySoundEffects("click");
            UIButtonHandler.OnStageSelectAndRestartButtonClicked(GameManager.Instance.selectedStage);
            Hide(); 
        });
        mainMenuBtn.onClick.AddListener(UIButtonHandler.OnMainMenuButtonClicked);
    }
}
