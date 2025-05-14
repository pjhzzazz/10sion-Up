using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessUI : BaseUI
{
    [Header("Buttons")]
    [SerializeField] private Button continueBtn;

    private void Awake()
    {
        continueBtn.onClick.AddListener(() =>
            {
                GameManager.Instance.NextStage();
                Hide();
            });
    }
}
