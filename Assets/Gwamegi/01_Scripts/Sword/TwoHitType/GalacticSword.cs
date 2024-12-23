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
            
            BlackHole item = Instantiate(_blackHole, transform.position, Quaternion.identity);
            item.Boom();
            OnAttackEvent?.Invoke();

            //m_RbCompo.velocity = Vector2.zero;
            testEnemy.GetDamage(damage);
            //StartCoroutine(DestroedObject());

            //isCanHit = false;
        }
    }
}