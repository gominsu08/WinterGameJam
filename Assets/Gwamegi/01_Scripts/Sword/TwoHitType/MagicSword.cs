using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSword : Sword
{
    [SerializeField] private BookBoom _bookBoom;

    private void Awake()
    {
        m_Rotation = -135;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CommonMob>(out CommonMob testEnemy) && isCanHit)
        {
            OnAttackEvent?.Invoke();

            BookBoom item = Instantiate(_bookBoom, transform.position, Quaternion.identity);
            item.Boom();

            //m_RbCompo.velocity = Vector2.zero;
            //StartCoroutine(DestroedObject());

            testEnemy.GetDamage(damage);
            //isCanHit = false;
        }
    }
}
