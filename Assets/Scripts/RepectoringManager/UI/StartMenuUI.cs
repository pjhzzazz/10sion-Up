using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuUI : BaseUI
{
    [Header("Buttons")]
    [SerializeField] private Button startBtn;
    [SerializeField] private Button optionBtn;

    private void Awake()
    {
        if (SaveSystem.SaveExists())
        {
            startBtn.onClick.AddListener(UIButtonHandler.OnMainMenuButtonClicked);
        }
        else startBtn.onClick.AddListener(GameManager.Instance.GameStory);

    }
}
