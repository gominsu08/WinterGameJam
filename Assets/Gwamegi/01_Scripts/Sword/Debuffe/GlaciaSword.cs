using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlaciaSword : Sword
{

    private float deBuffeRadius = 5;
    [SerializeField] private LayerMask _enemyLayerMask;
    [SerializeField] private ParticleSystem _particle;

    private void Awake()
    {
        m_Rotation = -135;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CommonMob>(out CommonMob testEnemy) && isCanHit)
        {
            //m_RbCompo.velocity = Vector2.zero;
            OnAttackEvent?.Invoke();

            Collider2D[] col = Physics2D.OverlapCircleAll(collision.transform.position, deBuffeRadius, _enemyLayerMask);

            foreach (Collider2D item in col)
            {
                CommonMob mon = item.GetComponent<CommonMob>();
                mon.DownSpeed();
                mon.TimeResetSpeedCoroutine(3);
                Instantiate(_particle, mon.gameObject.transform);
            }


            testEnemy.GetDamage(damage);



            //StartCoroutine(DestroedObject());

            //isCanHit = false;
        }
    }
}
