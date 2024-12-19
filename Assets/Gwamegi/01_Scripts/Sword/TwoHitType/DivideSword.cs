using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivideSword : Sword
{
    [SerializeField] private Projectile projectile;
    private void Awake()
    {
        m_Rotation = -135;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<TestEnemy>(out TestEnemy testEnemy))
        {

            testEnemy.Health--;
            Projectile project1 = Instantiate(projectile,transform.position,Quaternion.identity);
            project1.init(Vector2.up, transform.rotation);
            Projectile project2 = Instantiate(projectile, transform.position, Quaternion.identity);
            project2.init(Vector2.down, transform.rotation);
            m_RbCompo.velocity = Vector2.zero;
            StartCoroutine(DestroedObject());
        }
    }
}
