using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSword : Sword
{
    

    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<TestEnemy>(out TestEnemy testEnemy))
        {
            testEnemy.Health--;
            m_RbCompo.velocity = Vector2.zero;
        }
    }


}
