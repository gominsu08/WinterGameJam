using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float radius;
    public float pullForce;
    public LayerMask enemyMask;

    public void Start()
    {
        StartCoroutine(DestroyBlackHole());
        StartCoroutine(PullEnemies());
    }

    private IEnumerator PullEnemies()
    {
        while (true)
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, radius, enemyMask);
            foreach (Collider enemy in enemies)
            {
                Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
                CommonMob mob = enemy.GetComponent<CommonMob>();
                if (rb != null)
                {
                    if (mob != null) mob.GetDamage(15);
                    Vector3 direction = (transform.position - enemy.transform.position).normalized;
                    rb.AddForce(direction * pullForce, ForceMode2D.Impulse);
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private IEnumerator DestroyBlackHole()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
