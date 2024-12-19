using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderboltSword : Sword
{
    [SerializeField] private ParticleSystem projectile;

    private void Awake()
    {
        m_Rotation = -135;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<TestEnemy>(out TestEnemy testEnemy))
        {
            //적한테 데미지 들어가는 부분 제대로 만들어야함
            testEnemy.Health--;
            Instantiate(projectile,transform.position,transform.rotation);
            m_RbCompo.velocity = Vector2.zero;
            StartCoroutine(DestroedObject());
        }
    }
}
