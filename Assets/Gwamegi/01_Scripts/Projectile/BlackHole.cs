using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayerMask;
    [SerializeField] private float radius;

    public void Boom()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, _enemyLayerMask);

        foreach (Collider2D item in colliders)
        {
            if (item.gameObject.TryGetComponent<CommonMob>(out CommonMob component))
            {
                component.GetDamage(200);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
