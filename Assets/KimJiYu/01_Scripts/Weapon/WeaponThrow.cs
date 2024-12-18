using System;
using System.Collections;
using UnityEngine;

public class WeaponThrow : MonoBehaviour
{
    public event Action<int> OnThrowWeapon;

    private SpriteRenderer _sprite;
    private GetWeapon _currentWeaponData;

    private int _currentWeaponId;

    private bool _minThrow = false;
    public float _chargeValue = 0;
    private float _oldRotationZ = 0;

    private void Awake()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _currentWeaponData = GameObject.Find("CheckWeapon").GetComponent<GetWeapon>();
    }

    private void Start()
    {
        _oldRotationZ = transform.localRotation.z;
    }

    private void Update()
    {
        _currentWeaponId = _currentWeaponData.swordId;

        if (Input.GetMouseButton(0))
            ChargeWeapon();
        else if(Input.GetMouseButtonUp(0) && !_minThrow)
            ThrowWeapon();
    }

    private void ChargeWeapon()
    {
        Debug.Log("Â÷Â¡");
        if(_chargeValue < 700)
            _chargeValue += Time.deltaTime * 1000;
        else if (_chargeValue >= 700 && _chargeValue <= 2000)
            _chargeValue += Time.deltaTime * 1300;
        else if(_chargeValue >= 2000)
            _chargeValue += Time.deltaTime * 2000;
        transform.localRotation = Quaternion.Euler(0,0,_chargeValue);
    }

    private void ThrowWeapon()
    {
        Debug.Log("´øÁü");
        _sprite.enabled = false;
        transform.localRotation = Quaternion.Euler(0,0,_oldRotationZ);
        OnThrowWeapon?.Invoke(_currentWeaponId);
    }
}
