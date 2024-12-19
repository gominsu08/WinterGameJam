using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSword : Sword
{
    private float deBuffeRadius = 4;
    [SerializeField] private LayerMask _enemyLayerMask;

    private void Awake()
    {
        m_Rotation = -135;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CommonMob>(out CommonMob testEnemy) && isCanHit)
        {
            m_RbCompo.velocity = Vector2.zero;
            OnAttackEvent?.Invoke();

            Collider2D[] col = Physics2D.OverlapCircleAll(collision.transform.position, deBuffeRadius, _enemyLayerMask);

            foreach (Collider2D item in col)
            {
                CommonMob mon = item.GetComponent<CommonMob>();
                mon.FilpSpeed();
                mon.TimeFlipSpeed(5);
            }


            testEnemy.GetDamage(damage);



            StartCoroutine(DestroedObject());

            isCanHit = false;
        }
    }
}
