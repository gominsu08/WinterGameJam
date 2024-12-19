using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwordManager : MonoSingleton<SwordManager>
{
    [SerializeField] private SwordObjectListSO _swordObjectListSO;
    [SerializeField] private GetWeapon _getWeapon;
    [SerializeField] private Transform _positionTransform;

    public UnityEvent OnThrowSwordEvent;

    public bool isCanDuobleAttack = false;
    
    public void SwordCreate(int index)
    {
        foreach (Sword item in _swordObjectListSO.swords)
        {
            if (item.GetComponent<SwordDataContains>().GetSwordDataSO().swordNumber == index)
            {
                Sword swordItem = Instantiate(item,transform.position,Quaternion.identity);
                swordItem.ThrowSword(_positionTransform.position);
                swordItem.isCanHit = true;
                OnThrowSwordEvent?.Invoke();

                if (isCanDuobleAttack && 1 != index)
                {
                    StartCoroutine(SwordCreateTwo(item));
                }
            }
        }
    }

    private IEnumerator SwordCreateTwo(Sword item)
    {
        yield return new WaitForSeconds(0.25f);
        Sword swordItem2 = Instantiate(item, transform.position, Quaternion.identity);
        swordItem2.ThrowSword(_positionTransform.position);
        swordItem2.isCanHit = true;
        OnThrowSwordEvent?.Invoke();
        isCanDuobleAttack = false;
    }
}
