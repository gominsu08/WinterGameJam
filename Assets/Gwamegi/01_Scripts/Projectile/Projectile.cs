using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected LayerMask m_EnemyLayer;
    [SerializeField] protected Rigidbody2D m_RbCompo;
    [SerializeField] private float speed = 20f;
    private Vector2 _direction;

    public void init(Vector2 direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        m_RbCompo.velocity = _direction * speed;
    }
}
