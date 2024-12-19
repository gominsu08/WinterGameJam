using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class CommonMob : MonoBehaviour
{
    public float _dmg;

    [SerializeField] private float _hp;
    [SerializeField] private float _speed;
    [SerializeField] private float _attackTargetDistance; // 플레이어를 공격하는 거리
    [SerializeField] private int _coin;
    [SerializeField] private LayerMask _targetLayer;

    private SpriteRenderer _spriteRenderer;
    private Sprite _sprite;
    private Transform _targetObject;
    private Rigidbody2D _rigid;
    private Animator _animator;
    private Vector2 _targetPosition;


    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _targetObject = GameObject.FindWithTag("Player").transform;
        _animator = GetComponentInChildren<Animator>();
        _rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _sprite = _spriteRenderer.sprite;
        StartCoroutine(CheckTargetPosition(2f)); 
    }

    private void Update()
    {
        Move();
    }

    private void SwordInit(GameObject sword)
    {
        // 무기 쥐어주면 될 듯
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

        StartCoroutine(AfterDeadCoroutine(UnityEngine.Random.Range(1, 3)));
        TopUI.instance.GetCoin(_coin);

        _animator.Play("Dead");
    }
    public void GetDamage(float damage)
    {
        _animator.SetBool("Move", false);
        _animator.SetTrigger("Hit");
        _animator.ResetTrigger("Dead");

        _hp -= damage;

        _animator.Play("Hit");
    }
    private IEnumerator CheckTargetPosition(float time)
    {
        _targetPosition = _targetObject.position - transform.position;

        if (_targetObject.position.x < transform.position.x)
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;

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
        transform.DOScale(0, 1);
    }
}

