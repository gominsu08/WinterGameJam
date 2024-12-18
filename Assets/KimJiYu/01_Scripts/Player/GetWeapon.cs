using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWeapon : MonoBehaviour
{
    public int swordId;
    public Sprite weaponIcon;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword"))
        {
            if (collision.gameObject.TryGetComponent(out SwordDataContains swordData))
            {
                weaponIcon = swordData.GetSwordSprite();
                swordId = swordData.GetSwordId();
            }
        }
    }
}
