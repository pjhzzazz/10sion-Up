using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuUI : BaseUI
{
    [Header("Buttons")]
    [SerializeField] private Button startBtn;
    [SerializeField] private Button optionBtn;

    public GameObject optionPanel;

    private void Awake()
    {
        startBtn.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlaySoundEffects("click");
            UIButtonHandler.OnMainMenuButtonClicked();
        });
        optionBtn.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlaySoundEffects("click");
            optionPanel.SetActive(true);
        });
    }
}
