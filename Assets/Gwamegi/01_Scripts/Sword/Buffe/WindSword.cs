using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSword : Sword
{
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

            Player player = GameObject.FindAnyObjectByType<Player>();
            player._moveSpeed += 4;
            testEnemy.GetDamage(damage);


            player.StartCoroutine(MoveSpeedRerole(player));
            StartCoroutine(DestroedObject());

            isCanHit = false;
        }
    }

    private IEnumerator MoveSpeedRerole(Player player)
    {
        yield return new WaitForSeconds(3);
        player._moveSpeed -= 4;
    }
}
