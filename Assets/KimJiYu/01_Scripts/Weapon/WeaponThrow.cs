using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class WeaponThrow : MonoBehaviour
{
    public static WeaponThrow Instance;

    public event Action<int> OnThrowWeapon;

    public SpriteRenderer _sprite;
    private GetWeapon _currentWeaponData;

    public int _currentWeaponId;
    public bool isOwnWeapon = false;
    private float _chargeValue = 0;

    private bool _minThrow = false;

    private Sequence _sequence;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);

        _sprite = GetComponentInChildren<SpriteRenderer>();
        _currentWeaponData = GameObject.Find("CheckWeapon").GetComponent<GetWeapon>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        OnThrowWeapon += Test;
        _currentWeaponId = _currentWeaponData.swordId;

        if (Input.GetMouseButton(0) && !isOwnWeapon)
            ChargeWeapon();
        else if(Input.GetMouseButtonUp(0) && !_minThrow && !isOwnWeapon)
            ThrowWeapon();
    }

    private void Test(int value)
    {
        Debug.Log("sex");
    }

    private void ChargeWeapon()
    {
        Debug.Log("��¡");
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
        Debug.Log("����");

        if (_chargeValue < 300)
        {
            isOwnWeapon = true;
            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOLocalRotate(new Vector3(0, 0, 360f), 0.3f, RotateMode.FastBeyond360));
            _sequence.OnComplete(() => DisableThrow());

        }
        else
        {
            isOwnWeapon = true;
            DisableThrow();
        }
    }
    private void DisableThrow()
    {
        _sprite.enabled = false;
        _chargeValue = 0;
        transform.localRotation = Quaternion.Euler(0, 0, _chargeValue);
        OnThrowWeapon?.Invoke(_currentWeaponId);
    }

    private void GetWeaponSptire()
    {

    }
}
