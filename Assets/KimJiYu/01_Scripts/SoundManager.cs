using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SoundManager : MonoSingleton<SoundManager>
{
    public AudioMixer mixer;
    public AudioSource bgSound;
    public AudioClip bgClip;

    private void Awake()
    {
        BgSoundPlay(bgClip);
    }

    public void SfxSoundValue(float value)
    {
        mixer.SetFloat("SfxSound", Mathf.Log10(value) * 20);
    }

    public void BGSoundValue(float value)
    {
        mixer.SetFloat("BgSound", Mathf.Log10(value) * 20);
    }

    public void SFXPlay(string name, AudioClip clip)
    {
        GameObject go = new GameObject(name + "Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(go,clip.length);
    }

    public void BgSoundPlay(AudioClip clip)
    {
        bgSound.outputAudioMixerGroup = mixer.FindMatchingGroups("BGM")[0];
        bgSound.clip = clip;
        bgSound.loop = true;
        bgSound.volume = 0.5f;
        bgSound.Play();
    }
}
