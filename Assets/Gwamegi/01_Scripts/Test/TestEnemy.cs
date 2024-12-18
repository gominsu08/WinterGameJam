using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public int Health = 1;

    private void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        } 
    }
}
