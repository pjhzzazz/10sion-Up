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
        startBtn.onClick.AddListener(UIButtonHandler.OnMainMenuButtonClicked);
        optionBtn.onClick.AddListener(() => optionPanel.SetActive(true));
    }
}
