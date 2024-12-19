using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalacticSword : Sword
{
    [SerializeField] private BlackHole _blackHole;

    private void Awake()
    {
        m_Rotation = -135;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CommonMob>(out CommonMob testEnemy) && isCanHit)
        {
            testEnemy.GetDamage(damage);
            OnAttackEvent?.Invoke();

            BlackHole item = Instantiate(_blackHole, transform.position, Quaternion.identity);
            item.Boom();

            m_RbCompo.velocity = Vector2.zero;
            StartCoroutine(DestroedObject());

            isCanHit = false;
        }
    }
}