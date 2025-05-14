using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource bgmSource;
    public AudioSource soundEffectSource;

    public AudioClip[] bgms;
    public AudioClip[] soundEffects;

    public Dictionary<string, AudioClip> bgmDict = new();
    public Dictionary<string, AudioClip> soundEffectDict = new(); //»ç¿îµå ÀÌÆåÆ®

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            foreach (AudioClip clip in bgms)
                bgmDict[clip.name] = clip;

            foreach (AudioClip clip in soundEffects)    //µñ¼Å³Ê¸®¿¡ µî·Ï
                soundEffectDict[clip.name] = clip;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaysoundEffects(string name)
    {
        if (soundEffectDict.ContainsKey(name))
            soundEffectSource.PlayOneShot(soundEffectDict[name]);
    }

    public void PlayBGM(string name)
    {
        if (bgmDict.ContainsKey(name))
        {
            bgmSource.clip = bgmDict[name];
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }

    public void StopBGM() => bgmSource.Stop();
}

