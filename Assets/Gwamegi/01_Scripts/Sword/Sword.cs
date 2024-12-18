using System;
using System.Collections;
using UnityEngine;

public abstract class Sword : MonoBehaviour
{
    [SerializeField] private GameObject _visual;
    protected SwordDataSO m_SwordDataSO;
    protected LayerMask m_LayerMask;
    protected Vector2 m_Position;
    protected Rigidbody2D m_RbCompo;
    protected float m_Rotation = -135;
    [SerializeField] private bool _isCommonSword;

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
            if (_isCommonSword)
                m_RbCompo.velocity = Vector2.zero;
            else if (!_isCommonSword)
            {
                m_RbCompo.velocity = Vector2.zero;
                StartCoroutine(DestroedObject());
            }
        }
    }

    private IEnumerator DestroedObject()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }

    public virtual void ThrowSword(Vector2 targetPos)
    {
        DistanceCalculation(targetPos);

        Vector2 direction = (targetPos - (Vector2)transform.position);
        float desiredAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _visual.transform.rotation = Quaternion.AngleAxis(desiredAngle + m_Rotation, Vector3.forward);
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
