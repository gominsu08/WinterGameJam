using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoSingleton<CameraShake>
{
    private CinemachineVirtualCamera virtualC;
    private CinemachineBasicMultiChannelPerlin noise;

    private void Awake()
    {
        virtualC = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        noise = virtualC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera()
    {
        noise.m_FrequencyGain = 0.1f;
    }

    public void BigShake()
    {
        noise.m_AmplitudeGain = 5f;
    }

    public void StopShake()
    {
        noise.m_AmplitudeGain = 1.5f;
        noise.m_FrequencyGain = 0f;
    }
}

