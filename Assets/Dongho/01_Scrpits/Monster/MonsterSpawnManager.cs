using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnManager : MonoBehaviour
{
    [SerializeField] private float _monsterSpawnTime = 5f;
    [SerializeField] private float _maxSpawnDistance = 5f;
    [SerializeField] private float _minSpawnDistance = 3f;

    private GameObject[] _commonMobs;
    private GameObject[] _rushMobs;
    private GameObject[] _selfBombMobs;
    private Camera _camera;
    private Vector3 _minSpawnPoint;
    private Vector3 _maxSpawnPoint;
    private int monsterTypeRand;
    private int monsterRand;

    private void Awake()
    {
        _camera = Camera.main;
        _commonMobs = Resources.LoadAll<GameObject>("PoolObjects/Monster/Common");
        _rushMobs = Resources.LoadAll<GameObject>("PoolObjects/Monster/Rush");
        _selfBombMobs = Resources.LoadAll<GameObject>("PoolObjects/Monster/SelfBomb");
    }

    public void RandMonster()
    {
        monsterTypeRand = Random.Range(0, 1);

        switch (monsterTypeRand)
        {
            case 0:
                monsterRand = Random.Range(0, _commonMobs.Length);
                SpawnMonster(monsterRand);
                break;
            case 1:
                monsterRand = Random.Range(0, _rushMobs.Length);
                SpawnMonster(monsterRand);
                break;
            case 2:
                monsterRand = Random.Range(0, _selfBombMobs.Length);
                SpawnMonster(monsterRand);
                break;
            default:
                break;
        }
    }
    private void SpawnMonster(int num)
    {
        Vector2 position = Vector2.zero + Random.insideUnitCircle * _maxSpawnDistance;

        while (Vector3.Distance(position, Vector3.zero) <= _minSpawnDistance)
        {
            position = Vector3.zero + Random.insideUnitSphere * _maxSpawnDistance;
        }

        PoolManager.instance.PoolingObj("Monster", num).Get((value) =>
        {
            value.transform.position = position;
        });
    }
}
