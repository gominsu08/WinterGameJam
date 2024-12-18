using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public abstract class Sword : MonoBehaviour
{
    [SerializeField] private GameObject _visual;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ThrowSword(new Vector2(6, 3));
        }

        if ((m_Position.x + 0.5f > transform.position.x && m_Position.x - 0.5f < transform.position.x) && (m_Position.y + 0.5f > transform.position.y && m_Position.y - 0.5f < transform.position.y))
        {
            m_RbCompo.velocity = Vector2.zero;
        }
    }


    public virtual void ThrowSword(Vector2 targetPos)
    {
        DistanceCalculation(targetPos);

        Vector2 direction = (targetPos - (Vector2)transform.position);
        float desiredAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _visual.transform.rotation = Quaternion.AngleAxis(desiredAngle - 45, Vector3.forward);
        m_RbCompo.velocity = direction.normalized * m_SwordDataSO.speed;
    }

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
