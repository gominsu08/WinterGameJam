using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoSingleton<SoundManager>
{
    
    [SerializeField] private SoundListSo _soundListSo;
    [SerializeField] private AudioMixer _mixer;

    private void Start()
    {
    }


    public void PlaySound(string soundName)
    {
        GameObject obj = new GameObject();
        obj.name = soundName + " Sound";
        AudioSource source = obj.AddComponent<AudioSource>();
        SoundSo so = _soundListSo.SoundsDictionary[soundName];
        if(so.soundType == SoundType.SFX)
            source.outputAudioMixerGroup = _mixer.FindMatchingGroups("Master")[2];
        else if(so.soundType == SoundType.BGM)
        {
            source.outputAudioMixerGroup = _mixer.FindMatchingGroups("Master")[1];
        }
        else
        {
            Debug.LogWarning("Type이 없습니다");
            source.outputAudioMixerGroup = _mixer.FindMatchingGroups("Master")[0];

        }
        SetAudio(source,so);
        
    }

    private void SetAudio(AudioSource source,SoundSo sounds)
    {
        source.clip = sounds.clip;
        source.loop = sounds.loop;
        source.priority = sounds.Priority;
        source.volume = sounds.volume;
        source.pitch = sounds.pitch;
        source.panStereo = sounds.stereoPan;
        source.spatialBlend = sounds.SpatialBlend;
        source.Play();
        if (!sounds.loop) { StartCoroutine(DestroyCo(source.clip.length,source.gameObject)); }

    }

    IEnumerator DestroyCo(float endTime,GameObject obj)
    {
        yield return new WaitForSecondsRealtime(endTime);
        Destroy(obj);
    }
}

public enum SoundType
{
    BGM,
    SFX
}