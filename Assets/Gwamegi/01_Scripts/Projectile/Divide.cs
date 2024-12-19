using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Divide : Projectile
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CommonMob>(out CommonMob testEnemy))
        {
            //������ ������ ���� �κ� ����� ��������
            testEnemy.GetDamage(25);
            Destroy(gameObject);


        }
    }

}
