using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWeapon : MonoBehaviour
{
    private SwordDataContains _swordData;

    public SwordDataSO _swordDataSO;
    private bool _canPickUp;

    public int swordId;
    public Sprite weaponIcon;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out SwordDataContains swordData))
        {
            _swordData = swordData;
            _canPickUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out SwordDataContains swordData))
        {
            _canPickUp = false;
        }
    }

    private void Update()
    {
        if (_swordData != null && _canPickUp)
        {
            if (Input.GetMouseButtonDown(0) && WeaponThrow.Instance.isOwnWeapon)
            {
                StartCoroutine(OwnCoolTime());
            }
        }
    }

    private IEnumerator OwnCoolTime()
    {
        if (_swordData != null)
        {
            yield return new WaitForSeconds(1);
            _swordDataSO = _swordData.GetSwordDataSO();
            weaponIcon = _swordData.GetSwordSprite();
            WeaponThrow.Instance._sprite.sprite = weaponIcon;
            WeaponThrow.Instance._sprite.enabled = true;
            swordId = _swordData.GetSwordId();
            WeaponThrow.Instance.isOwnWeapon = false;
        }
    }
}
