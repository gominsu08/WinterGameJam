using UnityEngine;
using UnityEngine.Tilemaps;

public class MonsterSpawnManager : MonoBehaviour
{
    [SerializeField] private float _waveTime = 5f;
    [SerializeField] private Tilemap _tilemap;

    private int wave;
    private Transform _playerTransform;
    private int _waveCount = 0;
    private int monsterCount = 0;
    private float rand = 20;

    private void Start()
    {
        TopUI.instance.OnNextWave += () =>
        {
            _waveCount++;
            SpawnMonster();
            TopUI.instance.SetWaveText(_waveCount);
        };
        _playerTransform = GameObject.FindWithTag("Player").transform;
    }
    public void SpawnMonster()
    {
        monsterCount = 0;
        if (_waveCount > 20)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < _waveCount - 10; i++)
                {
                    monsterCount++;
                    Vector2 position = GetRandomPointInTilemap();
                    while (InScreen(position))
                    {
                        position = GetRandomPointInTilemap();
                    }
                    RandomPoolMonster(position);
                }
            }
            for (int i = 0; i < 12; i++)
            {
                monsterCount++;
                Vector2 position = GetRandomPointInTilemap();
                while (InScreen(position))
                {
                    position = GetRandomPointInTilemap();
                }

                PoolManager.instance.PoolingObj("Knight_oracle").Get((value) =>
                {
                    value.transform.position = position;
                    value.GetComponent<CommonMob>().SetName("Knight_oracle");
                });
            }
            WaveManager.Instance.enemyCount = monsterCount;
            TopUI.instance.SetEnemyCount(WaveManager.Instance.enemyCount);
            return;
        }
        if (_waveCount <= 7)
        {
            if(Random.Range(1, 101) < rand)
            {
                rand = 20;
                monsterCount++;
                Vector2 position = GetRandomPointInTilemap();
                while (InScreen(position))
                {
                    position = GetRandomPointInTilemap();
                }

                PoolManager.instance.PoolingObj("Wanderer_explorer").Get((value) =>
                {
                    value.transform.position = position;
                    value.GetComponent<CommonMob>().SetName("Wanderer_explorer");
                });
            }
            else
            {
                rand += 20;
            }
        }
        if (_waveCount <= 14 && _waveCount >= 8)
        {
            if (Random.Range(1, 101) < rand)
            {
                rand = 20;
                monsterCount++;
                Vector2 position = GetRandomPointInTilemap();
                while (InScreen(position))
                {
                    position = GetRandomPointInTilemap();
                }

                PoolManager.instance.PoolingObj("Wanderer_knight").Get((value) =>
                {
                    value.transform.position = position;
                    value.GetComponent<CommonMob>().SetName("Wanderer_knight");
                });
            }
            else
            {
                rand += 20;
            }
        }
        if (_waveCount >= 15)
        {
            if (Random.Range(1, 101) < rand)
            {
                rand = 20;
                monsterCount++;
                Vector2 position = GetRandomPointInTilemap();
                while (InScreen(position))
                {
                    position = GetRandomPointInTilemap();
                }

                PoolManager.instance.PoolingObj("Wanderer_darkknight").Get((value) =>
                {
                    value.transform.position = position;
                    value.GetComponent<CommonMob>().SetName("Wanderer_darkknight");
                });
            }
            else
            {
                rand += 20;
            }
        }

        for (int j = 0; j < CSVReader.instance.dicMenu[_waveCount].monsters.Length; j++)
        {
            for (int i = 0; i < int.Parse(CSVReader.instance.dicMenu[_waveCount].monsterNumber[j]); i++)
            {
                monsterCount++;
                Vector2 position = GetRandomPointInTilemap();
                while (InScreen(position))
                {
                    position = GetRandomPointInTilemap();
                }
                PoolMonster(position, j);
            }
        }
        WaveManager.Instance.enemyCount = monsterCount;
        Debug.Log(monsterCount);
        TopUI.instance.SetEnemyCount(WaveManager.Instance.enemyCount);
    }
    private void PoolMonster(Vector2 position, int n)
    {
        PoolManager.instance.PoolingObj(CSVReader.instance.dicMenu[_waveCount].monsters[n]).Get((value) =>
        {
            value.transform.position = position;
            value.GetComponent<CommonMob>().SetName(CSVReader.instance.dicMenu[_waveCount].monsters[n]);
        });
    }
    private void RandomPoolMonster(Vector2 position)
    {
        wave = Random.Range(1, 21);
        int monster = Random.Range(0, CSVReader.instance.dicMenu[wave].monsters.Length);

        PoolManager.instance.PoolingObj(CSVReader.instance.dicMenu[wave].monsters[monster]).Get((value) =>
        {
            monsterCount++;
            value.transform.position = position;
            value.GetComponent<CommonMob>().SetName(CSVReader.instance.dicMenu[wave].monsters[monster]);
        });
    }
    private Vector2 GetRandomPointInTilemap()
    {
        // Ÿ�ϸ��� ���(BoundsInt)�� �����ɴϴ�.
        BoundsInt bounds = _tilemap.cellBounds;

        for (int attempt = 0; attempt < 10000; attempt++) // �ִ� 100�� �õ�
        {
            // Ÿ�ϸ��� ������ �� ��ǥ�� �����ɴϴ�.
            int x = Random.Range(bounds.xMin, bounds.xMax);
            int y = Random.Range(bounds.yMin, bounds.yMax);
            Vector3Int cellPosition = new Vector3Int(x, y, 0);

            // �ش� ��ġ�� Ÿ���� �����ϴ��� Ȯ��
            if (_tilemap.HasTile(cellPosition))
            {
                return _tilemap.GetCellCenterWorld(cellPosition);
            }
        }

        // ���� �� Vector3.zero ��ȯ
        return Vector3.zero;
    }
    private bool InScreen(Vector2 position)
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(position);

        bool isVisible = viewportPosition.x >= 0 && viewportPosition.x <= 1 &&
                        viewportPosition.y >= 0 && viewportPosition.y <= 1 &&
                        viewportPosition.z > 0; // z���� ī�޶� �տ� �־�� ��

        return isVisible;
    }
}
