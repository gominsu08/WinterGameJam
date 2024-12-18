using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSword : Sword
{
    [SerializeField] private GameObject _visual;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ThrowSword(new Vector2(6,3));
        }

        if ((m_Position.x + 0.5f > transform.position.x && m_Position.x - 0.5f < transform.position.x ) && (m_Position.y + 0.5f > transform.position.y && m_Position.y - 0.5f < transform.position.y))
        {
            m_RbCompo.velocity = Vector2.zero;
        }
        
    }

    public override void ThrowSword(Vector2 location)
    {
        DistanceCalculation(location);

        Vector2 direction = (location - (Vector2)transform.position);
        float desiredAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _visual.transform.rotation = Quaternion.AngleAxis(desiredAngle - 45, Vector3.forward);
        m_RbCompo.velocity = direction.normalized * m_SwordDataSO.speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<TestEnemy>(out TestEnemy testEnemy))
        {
            testEnemy.Health--;
            m_RbCompo.velocity = Vector2.zero;
        }
    }


}
