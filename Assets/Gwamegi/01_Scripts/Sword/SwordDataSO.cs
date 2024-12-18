using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "SO/Sword/SwordDataSO")]
public class SwordDataSO : ScriptableObject
{
    /// <summary>
    /// 검의 넘버
    /// </summary>
    public int swordNumber;

    /// <summary>
    /// 데미지
    /// </summary>
    public int damage;
    /// <summary>
    /// 속도
    /// </summary>
    public float speed;
    /// <summary>
    /// 사정거리
    /// </summary>
    public float intersection;
    /// <summary>
    /// 줍기 딜레이 시간
    /// </summary>
    public float pickUpDelayTime;
    /// <summary>
    /// 검의 사이즈
    /// </summary>
    public float size;


    /// <summary>
    /// 칼 이미지
    /// </summary>
    public Sprite swordSprite;
}
