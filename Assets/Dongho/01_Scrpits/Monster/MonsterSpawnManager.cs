using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnManager : MonoBehaviour
{
    [SerializeField] private float _monsterSpawnTime = 5f;
    [SerializeField] private float _maxSpawnDistance = 30f;
    [SerializeField] private float _minSpawnDistance = 10f;

    private int _waveCount = 1;

    private void Start()
    {
        StartCoroutine(das());
    }
    private IEnumerator das()
    {
        yield return new WaitForSeconds(0.5f);
        SpawnMonster();
    }
    public void SpawnMonster()
    {
        for (int j = 0; j < CSVReader.instance.dicMenu[_waveCount].monsters.Length; j++)
        {
            for(int i = 0; i < int.Parse(CSVReader.instance.dicMenu[_waveCount].monsterNumber[j]); i++)
            {
                Vector2 position = Vector2.zero + Random.insideUnitCircle * _maxSpawnDistance;

                while (Vector3.Distance(position, Vector3.zero) <= _minSpawnDistance)
                {
                    position = Vector3.zero + Random.insideUnitSphere * _maxSpawnDistance;
                }

                PoolManager.instance.PoolingObj(CSVReader.instance.dicMenu[_waveCount].monsters[j]).Get((value) =>
                {
                    value.transform.position = position;
                });
            }
        }
        
    }
}
