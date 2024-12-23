using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundListSo", menuName = "SO/Sound/SoundListSo")]
public class SoundListSo : ScriptableObject
{
    [SerializeField] private List<SoundSo> sounds;

    // ��Ÿ�ӿ��� �����ϱ� ���� ��ųʸ� (����ȭ���� ����)
    private Dictionary<string, SoundSo> _soundsDictionary;

    // ��ųʸ��� �ʱ�ȭ�ϴ� �Ӽ�
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

    // ��ųʸ��� �ʱ�ȭ�ϴ� �޼���
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

    // Unity �����Ϳ��� �����͸� ������Ʈ
    private void OnValidate()
    {
        InitializeDictionary();
    }
}