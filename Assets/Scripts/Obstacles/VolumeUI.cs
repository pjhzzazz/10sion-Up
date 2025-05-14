using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeUI : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider soundEffectSlider;
    private float lastPlayTime = 0f;
    void Start()
    {
        // 초기화
        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1f);
        soundEffectSlider.value = PlayerPrefs.GetFloat("SoundEffectVolume", 1f);

        // 슬라이더 값 변경 시 AudioManager에 반영
        bgmSlider.onValueChanged.AddListener((value) =>
        {
            AudioManager.Instance.SetBGMVolume(value);
        });

        soundEffectSlider.onValueChanged.AddListener((value) =>
        {
            AudioManager.Instance.SetSoundEffectVolume(value);
            //if (Time.time - lastPlayTime > 0.5f)
            //{
            //    AudioManager.Instance.PlaySoundEffects("click");         //클릭소리로 미리듣기
            //    lastPlayTime = Time.time;
            //}
        });
    }
}
