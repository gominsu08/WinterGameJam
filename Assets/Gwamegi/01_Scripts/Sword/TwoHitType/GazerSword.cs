using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazerSword : Sword 
{
    [SerializeField] private Laser _laser;

    private void Awake()
    {
        m_Rotation = -135;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CommonMob>(out CommonMob testEnemy) && isCanHit)
        {
            

            Laser item = Instantiate(_laser, transform.position, Quaternion.identity);
            item.LayerShot();
            testEnemy.GetDamage(damage);
            OnAttackEvent?.Invoke();
            m_RbCompo.velocity = Vector2.zero;
            StartCoroutine(DestroedObject());

            isCanHit = false;
        }
    }
}
