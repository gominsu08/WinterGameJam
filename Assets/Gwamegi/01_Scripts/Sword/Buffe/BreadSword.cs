using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadSword : Sword
{
    private void Awake()
    {
        m_Rotation = -135;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CommonMob>(out CommonMob testEnemy) && isCanHit)
        {
            //StartCoroutine(DestroedObject());

            //m_RbCompo.velocity = Vector2.zero;
            OnAttackEvent?.Invoke();
            Health.Instance.GetHit(-30);

            

            testEnemy.GetDamage(damage);

            //isCanHit = false;
        }
    }
}
