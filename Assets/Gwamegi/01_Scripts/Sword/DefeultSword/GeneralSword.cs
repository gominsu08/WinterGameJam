using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralSword : Sword
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CommonMob>(out CommonMob testEnemy) && isCanHit)
        {
            testEnemy.GetDamage(damage);
            m_RbCompo.velocity = Vector2.zero;
            OnAttackEvent?.Invoke();
            StartCoroutine(DestroedObject());

            isCanHit = false;
        }
    }
}
