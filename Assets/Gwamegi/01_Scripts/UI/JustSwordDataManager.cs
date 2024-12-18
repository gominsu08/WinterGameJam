using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustSwordDataManager : MonoSingleton<JustSwordDataManager>
{
    private int _atk = 15;
    private float _speed = 3f;
    private float _range = 7f;
    private float _size = 1f;
    private float _pickDelay = 0.5f;

    public int GetAtk() => _atk;
    public float GetSpeed() => _speed;
    public float GetRange() => _range;
    public float GetPickDelay() => _pickDelay;
    public float GetSize() => _size;

    public void SetAtk(int count)
    {
        _atk += count;
    }

    public void SetSpeed(float count)
    {
        _speed += count;
    }
    public void SetRange(float count)
    {
        _range += count;
    }

    public void SetPickDelay(float count)
    {
        _size += count;
    }

    public void SetSize(float count)
    {
        _size += count;
    }

}
