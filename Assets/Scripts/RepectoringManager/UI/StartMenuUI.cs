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
        startBtn.onClick.AddListener(UIButtonHandler.OnMainMenuButtonClicked);
    }
}
