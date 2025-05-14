using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseOptionButton : MonoBehaviour
{
    public GameObject optionPanel;
    public Button closeButton;
    void Start()
    {
        closeButton.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlaySoundEffects("click");
            optionPanel.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
