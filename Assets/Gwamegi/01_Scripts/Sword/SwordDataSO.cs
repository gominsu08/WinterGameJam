using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "SO/Sword/SwordDataSO")]
public class SwordDataSO : ScriptableObject
{
    /// <summary>
    /// ���� �ѹ�
    /// </summary>
    public int swordNumber;

    /// <summary>
    /// ������
    /// </summary>
    public int damage;
    /// <summary>
    /// �ӵ�
    /// </summary>
    public float speed;
    /// <summary>
    /// �����Ÿ�
    /// </summary>
    public float intersection;
    /// <summary>
    /// �ݱ� ������ �ð�
    /// </summary>
    public float pickUpDelayTime;
    /// <summary>
    /// ���� ������
    /// </summary>
    public float size;


    /// <summary>
    /// Į �̹���
    /// </summary>
    public Sprite swordSprite;
}
