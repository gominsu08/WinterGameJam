using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected LayerMask m_EnemyLayer;

    public abstract void Boom();

    public void init()
    {

    }
}
