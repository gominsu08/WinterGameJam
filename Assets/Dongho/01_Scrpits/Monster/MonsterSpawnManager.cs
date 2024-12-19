using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.Rendering.DebugUI;

public class MonsterSpawnManager : MonoBehaviour
{
    [SerializeField] private float _waveTime = 5f;
    [SerializeField] private Tilemap _tilemap;

    private Transform _playerTransform;
    private int _waveCount = 1;

    private void Start()
    {
        StartCoroutine(das());
        _playerTransform = GameObject.FindWithTag("Player").transform;
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
            for (int i = 0; i < int.Parse(CSVReader.instance.dicMenu[_waveCount].monsterNumber[j]); i++)
            {
                Vector2 position = GetRandomPointInTilemap();
                while(InScreen(position))
                {
                    position = GetRandomPointInTilemap();
                }
                PoolMonster(position, j);
            }
        }
    }
    private void PoolMonster(Vector2 position, int n)
    {
        PoolManager.instance.PoolingObj(CSVReader.instance.dicMenu[_waveCount].monsters[n]).Get((value) =>
        {
            value.transform.position = position;
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
