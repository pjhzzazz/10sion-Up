using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectToggleButton : MonoBehaviour
{
    public Button soundEffectButton;
    public Image soundEffectImage;
    public Sprite soundEffectOnSprite;
    public Sprite SoundEffectOffSprite;

    private bool isMuted = false;

    private void Start()
    {
        soundEffectButton.onClick.AddListener(() => ToggleMute());
    }
    public void ToggleMute()
    {
        isMuted = !isMuted;
        AudioManager.Instance.MuteSoundEffect(isMuted);

        soundEffectImage.sprite = isMuted ? SoundEffectOffSprite : soundEffectOnSprite;
    }
}
