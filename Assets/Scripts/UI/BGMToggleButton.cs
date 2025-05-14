using UnityEngine;
using UnityEngine.UI;

public class BGMToggleButton : MonoBehaviour
{
    public Button bgmButton;
    public Image bgmImage;
    public Sprite bgmOnSprite;
    public Sprite bgmOffSprite;

    private bool isMuted = false;

    private void Start()
    {
        bgmButton.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlaySoundEffects("click");
            ToggleMute();
        });
    }
    public void ToggleMute()
    {
        isMuted = !isMuted;
        AudioManager.Instance.MuteBGM(isMuted);

        bgmImage.sprite = isMuted ? bgmOffSprite : bgmOnSprite;
    }
}
