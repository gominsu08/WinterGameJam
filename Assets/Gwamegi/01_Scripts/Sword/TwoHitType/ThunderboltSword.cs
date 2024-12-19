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
        if (collision.TryGetComponent<CommonMob>(out CommonMob testEnemy) && isCanHit)
        {
            //적한테 데미지 들어가는 부분 제대로 만들어야함
            Instantiate(projectile,transform.position,transform.rotation);
            m_RbCompo.velocity = Vector2.zero;
            OnAttackEvent?.Invoke();
            testEnemy.GetDamage(damage);
            StartCoroutine(DestroedObject());
            isCanHit = false;
        }
    }
}
