using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundListSo", menuName = "SO/Sound/SoundListSo")]
public class SoundListSo : ScriptableObject
{
    [SerializeField] private List<SoundSo> sounds;

    // 런타임에서 접근하기 위한 딕셔너리 (직렬화되지 않음)
    private Dictionary<string, SoundSo> _soundsDictionary;

    // 딕셔너리를 초기화하는 속성
    public Dictionary<string, SoundSo> SoundsDictionary
    {
        get
        {
            if (_soundsDictionary == null || _soundsDictionary.Count == 0)
            {
                InitializeDictionary();
            }
            return _soundsDictionary;
        }
    }

    // 딕셔너리를 초기화하는 메서드
    private void InitializeDictionary()
    {
        _soundsDictionary = new Dictionary<string, SoundSo>();
        foreach (var soundSo in sounds)
        {
            if (soundSo != null && !string.IsNullOrEmpty(soundSo.soundName))
            {
                if (!_soundsDictionary.ContainsKey(soundSo.soundName))
                {
                    _soundsDictionary[soundSo.soundName] = soundSo;
                }
                else
                {
                    Debug.LogWarning($"Duplicate sound name found: {soundSo.soundName}");
                }
            }
        }
    }

    // Unity 에디터에서 데이터를 업데이트
    private void OnValidate()
    {
        InitializeDictionary();
    }
}