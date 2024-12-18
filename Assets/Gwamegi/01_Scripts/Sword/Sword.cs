using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sword : MonoBehaviour
{
    protected SwordDataSO m_SwordDataSO;  
    protected LayerMask m_LayerMask;
    protected Vector2 m_Position;
    protected Rigidbody2D m_RbCompo;
    
    public virtual void Init(SwordDataSO swordDataSO, LayerMask obstacleLayerMask)
    {
        m_SwordDataSO = swordDataSO;
        m_LayerMask = obstacleLayerMask;
        m_RbCompo = GetComponent<Rigidbody2D>();
    }


    public abstract void ThrowSword(Vector2 targetPos);

    public virtual void DistanceCalculation(Vector2 targetPos)
    {
        Vector2 dir = targetPos - (Vector2)transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, m_SwordDataSO.intersection, m_LayerMask);

        if (hit)
            m_Position = hit.transform.position;
        else
            m_Position = targetPos;
    }


}
