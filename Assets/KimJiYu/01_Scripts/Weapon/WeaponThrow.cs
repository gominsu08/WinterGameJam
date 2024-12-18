using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WeaponThrow : MonoBehaviour
{
    public static WeaponThrow Instance;

    public UnityEvent<int> OnThrowWeapon;

    public SpriteRenderer _sprite;
    private PlayerMovement _player;
    private GetWeapon _currentWeaponData;

    public int _currentWeaponId;
    public bool isOwnWeapon = false;
    public bool isPickUp = false;
    public bool isCharging = false;
    private float _chargeValue = 0;

    private bool _minThrow = false;

    private Sequence _sequence;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);

        _player = GetComponentInParent<PlayerMovement>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _currentWeaponData = GameObject.Find("CheckWeapon").GetComponent<GetWeapon>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        _currentWeaponId = _currentWeaponData.swordId;

        if (Input.GetMouseButton(0) && !isOwnWeapon)
            ChargeWeapon();
        else if(Input.GetMouseButtonUp(0) && !_minThrow && !isOwnWeapon)
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
        _player._moveSpeed = 5;
    }

    private void ThrowWeapon()
    {
        Debug.Log("´øÁü");
        if (_chargeValue < 300)
        {
            _player._moveSpeed = 5;
            isOwnWeapon = true;
            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOLocalRotate(new Vector3(0, 0, 640f), 0.6f, RotateMode.FastBeyond360));
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
        _player._moveSpeed = 8;
        _chargeValue = 0;
        transform.localRotation = Quaternion.Euler(0, 0, _chargeValue);
        OnThrowWeapon?.Invoke(_currentWeaponId);
    }

    private void GetWeaponSptire()
    {

    }
}
