using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CommonMob : MonoBehaviour
{
    [SerializeField] private float _hp;
    [SerializeField] private float _dmg;
    [SerializeField] private float _speed;
    [SerializeField] private float _attackTargetDistance; // 플레이어를 공격하는 거리
    [SerializeField] private LayerMask _targetLayer;

    private Transform _targetObject;
    private Rigidbody2D _rigid;
    private Animator _animator;
    private Vector2 _targetPosition;

    private void Awake()
    {
        _targetObject = GameObject.FindWithTag("Player").transform;
        _animator = GetComponentInChildren<Animator>();
        _rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
        _targetPosition = (_targetObject.position - transform.position);
        
        if(_targetObject.position.x < transform.position.x)
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        else
            GetComponentInChildren<SpriteRenderer>().flipX = false;

        if (_animator.GetBool("Move"))
        {
            _targetPosition = _targetObject.position - transform.position;
            _rigid.velocity = _targetPosition.normalized * _speed;
        }
    }

    private void Move()
    {
        _animator.SetBool("Move", true);
        _animator.ResetTrigger("Hit");
        _animator.ResetTrigger("Dead");
    }
    private void Dead()
    {
        _animator.SetBool("Move", false);
        _animator.ResetTrigger("Hit");
        _animator.SetTrigger("Dead");

        // 때리기

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
    private void Run()
    {
    }
}
