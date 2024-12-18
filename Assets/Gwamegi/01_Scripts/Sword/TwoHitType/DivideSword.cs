using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivideSword : Sword
{
    [SerializeField] private Projectile projectile;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<TestEnemy>(out TestEnemy testEnemy))
        {

            testEnemy.Health--;
            Projectile project = Instantiate(projectile,transform.position,Quaternion.identity);
            project.init();
            Destroy(gameObject);
        }
    }
}
