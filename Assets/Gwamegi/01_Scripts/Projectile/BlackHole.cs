using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float pullSpeed = 40f;
    public float pullInterval = 0.5f;
    public float pullRadius = 5f;
    public LayerMask enemyLayer;

    private void Start()
    {
        StartCoroutine(PullEnemies());
    }

    private IEnumerator PullEnemies()
    {
        while (true)
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, pullRadius, enemyLayer);

            foreach (Collider2D enemy in enemies)
            {
                Transform enemyTransform = enemy.transform;

                if (enemyTransform != null)
                {
                    Vector3 direction = (transform.position - enemyTransform.position).normalized;
                    enemyTransform.position += direction * pullSpeed * Time.deltaTime;
                }
            }

            yield return new WaitForSeconds(pullInterval);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // 블랙홀 효과의 범위를 시각적으로 확인하기 위해 Gizmos 그리기
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, pullRadius);
    }

    private IEnumerator DestroyBlackHole()
    {
        yield return new WaitForSeconds(15f);
        Destroy(gameObject);
    }
}
