using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSword : Sword
{
    public override void Init(SwordDataSO swordDataSO, LayerMask obstacleLayerMask)
    {
        base.Init(swordDataSO, obstacleLayerMask);

        damage = JustSwordDataManager.Instance.GetAtk();
        speed = JustSwordDataManager.Instance.GetSpeed();
        intersection = JustSwordDataManager.Instance.GetRange();
        pickUpDelayTime = JustSwordDataManager.Instance.GetPickDelay();
        minSize = JustSwordDataManager.Instance.GetSize();
        maxSize = JustSwordDataManager.Instance.GetSize();
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
