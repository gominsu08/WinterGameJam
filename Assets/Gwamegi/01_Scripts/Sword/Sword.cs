using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sword : MonoBehaviour
{
    [SerializeField] protected SwordDataSO m_SwordDataSO;
    [SerializeField] protected LayerMask m_ObstacleLayerMask;
    protected Vector2 m_Position;
    

    public abstract void ThrowSword(Vector2 targetPos);

    public virtual void DistanceCalculation(Vector2 targetPos)
    {
        Vector2 dir = targetPos - (Vector2)transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, m_SwordDataSO.intersection, m_ObstacleLayerMask);

        if (hit)
            m_Position = hit.transform.position;
        else
            m_Position = targetPos;
    }


}
