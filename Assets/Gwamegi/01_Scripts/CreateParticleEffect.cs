using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateParticleEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    public void CreateParticle()
    {
        Instantiate(_particle, transform);
    }
}
