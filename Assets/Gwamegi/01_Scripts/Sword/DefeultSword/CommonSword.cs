using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSword : Sword
{
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ThrowSword(new Vector2(6,3));
        }

        if ((m_Position.x + 0.5f > transform.position.x && m_Position.x - 0.5f < transform.position.x ) && (m_Position.y + 0.5f > transform.position.y && m_Position.y - 0.5f < transform.position.y))
        {
            m_RbCompo.velocity = Vector2.zero;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<TestEnemy>(out TestEnemy testEnemy))
        {
            testEnemy.Health--;
            m_RbCompo.velocity = Vector2.zero;
        }
    }


}
