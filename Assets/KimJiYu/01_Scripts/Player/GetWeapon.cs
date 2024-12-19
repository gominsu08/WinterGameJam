using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GetWeapon : MonoBehaviour
{
    public UnityEvent OnPickUpSword;

    private SwordDataContains _swordData;
    private Image _weaponInfoIcon;
    private GameObject _destroySword;

    public SwordDataSO _swordDataSO;
    public float dis;
    private bool _canPickUp;

    public int swordId;
    public Sprite weaponIcon;

    private void Awake()
    {
        _weaponInfoIcon = GameObject.Find("WeaponIcon").GetComponent<Image>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out SwordDataContains swordData))
        {
            _canPickUp = true;
            _swordData = swordData;
            _destroySword = collision.gameObject;
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
                _weaponInfoIcon.enabled = true;
                _weaponInfoIcon.sprite = _swordData.GetSwordSprite();
                WeaponThrow.Instance.isPickUp = true;
                OnPickUpSword?.Invoke();
                StartCoroutine(OwnCoolTime());
                Destroy(_destroySword);
            }
        }
    }

    private IEnumerator OwnCoolTime()
    {
        if (_swordData != null)
        {
            _swordDataSO = _swordData.GetSwordDataSO();
            dis = _swordData.gameObject.GetComponent<Sword>().intersection;
            yield return new WaitForSeconds(_swordDataSO.pickUpDelayTime);
            weaponIcon = _swordData.GetSwordSprite();
            WeaponThrow.Instance._sprite.sprite = weaponIcon;
            WeaponThrow.Instance._sprite.enabled = true;
            swordId = _swordData.GetSwordId();
            WeaponThrow.Instance.isOwnWeapon = false;
            WeaponThrow.Instance.isPickUp = false;
        }
    }
}
