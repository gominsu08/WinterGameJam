using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    private void OnParticleCollision(GameObject collision)
    {
        Debug.Log("무언가");
        if(collision.TryGetComponent<CommonMob>(out CommonMob component))
        {
            Debug.Log("적");
            component.GetDamage(1);
        }
    }
}

