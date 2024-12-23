using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBoom : MonoBehaviour
{
    public Vector2 size;
    public LayerMask enemyLayerMask;

    public void Boom()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, size,0, enemyLayerMask);

        foreach (Collider2D item in colliders)
        {
            if(item.gameObject.TryGetComponent<CommonMob>(out CommonMob component))
            {
                component.GetDamage(70);
            }
        }

        StartCoroutine(GameObjectDestroy());
    }

    private IEnumerator GameObjectDestroy()
    {
        yield return new WaitForSeconds(0.75f);
        Destroy(gameObject);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, size);
    }
}
