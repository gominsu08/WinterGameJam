using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonMob : MonoBehaviour
{
    public float _dmg;

    [SerializeField] private float _hp;
    [SerializeField] private float _speed;
    [SerializeField] private float _attackTargetDistance; // 플레이어를 공격하는 거리
    [SerializeField] private int _coin;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private SwordObjectListSO _swordObjList;
    [SerializeField] private List<SwordGroupEnum> _swordGropEnums;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private SpriteRenderer _swordSpriteRenderer;
    [SerializeField] private float _dropPercent;

    private string _name;
    private Sprite _sprite;
    private Transform _targetObject;
    private Rigidbody2D _rigid;
    private Animator _animator;
    private Vector2 _targetPosition;
    private Sword _sword;
    private float speed;

    private void Awake()
    {
        _targetObject = GameObject.FindWithTag("Player").transform;
        _animator = GetComponentInChildren<Animator>();
        _rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _sprite = _spriteRenderer.sprite;
    }
    private void OnEnable()
    {
        SwordInit();
        StartCoroutine(CheckTargetPosition(UnityEngine.Random.Range(0.5f, 3f)));
        GetComponent<BoxCollider2D>().enabled = true;
        if (_speed == 0)
            _speed = speed;
        else
            speed = _speed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GetDamage(1000);
        }
        Move();
    }

    public void SetName(string name)
    {
        _name = name;
    }
    private void SwordInit()
    {
        if(UnityEngine.Random.Range(1,101) < _dropPercent)
        {
            int rand = UnityEngine.Random.Range(0, _swordGropEnums.Count);
            _sword = _swordObjList.GetSword(_swordGropEnums[rand]);
            Sprite sprite = _sword.GetComponent<SwordDataContains>().GetSwordSprite();
            _swordSpriteRenderer.sprite = sprite;
            _swordSpriteRenderer.transform.localPosition = new Vector3(0.7f, 0.1f, 0);
        }
    }
    private void Move()
    {
        _animator.SetBool("Move", true);
        _animator.ResetTrigger("Hit");
        _animator.ResetTrigger("Dead");
        
        if (_animator.GetBool("Move"))
        {
            _rigid.velocity = _targetPosition.normalized * _speed;
        }
        if (_attackTargetDistance > Vector2.Distance(_targetPosition, transform.position))
        {
            _rigid.velocity = Vector2.zero;
            _animator.SetBool("Move", false);
            _spriteRenderer.sprite = _sprite;
        }
        else
            _animator.SetBool("Move", true);
    }
    private void Dead()
    {
        _animator.SetBool("Move", false);
        _animator.ResetTrigger("Hit");
        _animator.SetTrigger("Dead");
        _animator.Play("Dead");

        _speed = 0;
        GetComponent<BoxCollider2D>().enabled = false;

        StartCoroutine(AfterDeadCoroutine(UnityEngine.Random.Range(1f, 3f)));
        TopUI.instance.PlusCoin(_coin);
        TopUI.instance.SetEnemyCount(--WaveManager.Instance.enemyCount);
    }
    public void GetDamage(float damage)
    {
        _animator.SetBool("Move", false);
        _animator.SetTrigger("Hit");
        _animator.ResetTrigger("Dead");
        _animator.Play("Hit");

        _hp -= damage;
        if(_hp <= 0)
        {
            Dead();
        }
    }
    private IEnumerator CheckTargetPosition(float time)
    {
        _targetPosition = _targetObject.position - transform.position;

        if (_targetObject.position.x < transform.position.x)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);

        yield return new WaitForSeconds(time);

        StartCoroutine(CheckTargetPosition(time));
    }
    private IEnumerator AfterDeadCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        AfterDead();
    }
    private void AfterDead()
    {
        _rigid.velocity = Vector3.zero;
        //transform.DOScale(0, 10);
        PoolManager.instance.poolDictionary[_name].Return(this.gameObject);
        if (_sword != null)
        {
            GameObject obj =  Instantiate(_sword).gameObject;
            obj.transform.position = transform.position;
        }
    }
    public void DownSpeed(int percent)
    {
        _speed *= percent / 100;
    }
    public void ZeroSpeed()
    {
        _speed *= 0;
    }
    public void FilpSpeed()
    {
        _speed *= -1;
    }
    public void SecDamage(int time, int damage)
    {
        StartCoroutine(SecDamageCoroutine(time, damage));
    }
    private IEnumerator SecDamageCoroutine(int time, int damage)
    {
        GetDamage(damage);
        yield return new WaitForSeconds(1f);
        time--;
        if (time <= 0)
            StopCoroutine("SecDamageCoroutine");
        StartCoroutine(SecDamageCoroutine(time, damage));
    }
}

