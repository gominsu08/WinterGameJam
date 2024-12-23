using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    private void OnParticleCollision(GameObject collision)
    {
        Debug.Log("����");
        if(collision.TryGetComponent<CommonMob>(out CommonMob component))
        {
            Debug.Log("��");
            component.GetDamage(1);
        }
    }
}

