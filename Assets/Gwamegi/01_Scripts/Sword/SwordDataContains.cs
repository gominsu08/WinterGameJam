using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDataContains : MonoBehaviour
{
    [SerializeField] private SwordDataSO _swordDataSO;
    [SerializeField] protected LayerMask _ObstacleLayerMask;
    [SerializeField] private Sword sword;

    private void Awake()
    {
        sword.Init(GetSwordDataSO(), GetLayerMask());
    }


    public SwordDataSO GetSwordDataSO() => _swordDataSO;

    public int GetSwordId() => _swordDataSO.swordNumber;

    public Sprite GetSwordSprite() => _swordDataSO.swordSprite;

    public LayerMask GetLayerMask() => _ObstacleLayerMask;
}
