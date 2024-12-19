using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static int enemyCount = 0;
    private int _enemyCount = 0;

    private void Start()
    {
        TopUI.instance.OnChangeEnemyCount += (value) =>
        {
            _enemyCount = value;
            enemyCount = _enemyCount;
        };
    }
}
