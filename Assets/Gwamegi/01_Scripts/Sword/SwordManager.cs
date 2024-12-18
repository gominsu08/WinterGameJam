using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour
{
    [SerializeField] private SwordObjectListSO _swordObjectListSO;
    [SerializeField] private GetWeapon _getWeapon;
    [SerializeField] private Transform _positionTransform;
    
    public void SwordCreate(int index)
    {
        foreach (Sword item in _swordObjectListSO.swords)
        {
            if (item.GetComponent<SwordDataContains>().GetSwordDataSO().swordNumber == index)
            {
                Sword swordItem = Instantiate(item,transform.position,Quaternion.identity);
                swordItem.ThrowSword(_positionTransform.position);
            }
        }
    }
}
