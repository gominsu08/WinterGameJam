using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetAudioMixer : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _Masterslider;
    [SerializeField] private Slider _BGMslider;
    [SerializeField] private Slider _SFXslider;


    private void Awake()
    {
        _Masterslider.value = PlayerPrefs.GetFloat("Master",1);
        _BGMslider.value = PlayerPrefs.GetFloat("BGM",1);
        _SFXslider.value = PlayerPrefs.GetFloat("SFX",1);
    }

    private void Start()
    {
        
        _audioMixer.SetFloat("Master", Mathf.Log10(_Masterslider.value) * 20);
        _audioMixer.SetFloat("BGM", Mathf.Log10(_BGMslider.value) * 20);
        _audioMixer.SetFloat("SFX", Mathf.Log10(_SFXslider.value) * 20);
    }

    public void SetMasterSound(float value)
    {
        if(value <= 1)
            _audioMixer.SetFloat("Master", Mathf.Log10(value) * 20);
        
    }
    public void SetBGMSound(float value)
    {
        if(value <= 1)
            _audioMixer.SetFloat("BGM", Mathf.Log10(value) * 20);
        
    }
    public void SetSFXSound(float value)
    {
        if(value <= 1)
            _audioMixer.SetFloat("SFX", Mathf.Log10(value) * 20);
        
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("Master",_Masterslider.value);
        PlayerPrefs.SetFloat("BGM",_BGMslider.value);
        PlayerPrefs.SetFloat("SFX",_SFXslider.value);
    }
}
