using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionBtn : MonoBehaviour
{
    [SerializeField] private Button optionBtn;

    private void Awake()
    {
        optionBtn.onClick.AddListener(GameManager.Instance.PauseGame);
    }
}
