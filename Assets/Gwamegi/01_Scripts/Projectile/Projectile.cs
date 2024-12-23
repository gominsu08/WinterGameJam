using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected LayerMask m_EnemyLayer;
    [SerializeField] protected Rigidbody2D m_RbCompo;
    [SerializeField] protected float m_LifeTime;
    [SerializeField] private float _speed = 20f;
    [SerializeField] private GameObject _visual;
    public Vector2 _direction;

    public void init(Vector2 direction, Quaternion rotation)
    {
        _direction = direction;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, angle);

        StartCoroutine(DestroyObject());
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(m_LifeTime);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position += transform.up * _speed * Time.deltaTime;
    }
}
