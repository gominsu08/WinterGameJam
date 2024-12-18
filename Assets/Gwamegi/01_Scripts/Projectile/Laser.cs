using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Projectile
{
    [SerializeField] private Vector2 _size;
    [SerializeField] private float radius;
    
    public override void Boom()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, radius, m_EnemyLayer);
        Collider col;

        foreach (Collider2D item in collider)
        {

        }
    }
}
