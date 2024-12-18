using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CommonMob : Monster
{
    [SerializeField] private float _hp;
    [SerializeField] private float _dmg;
    [SerializeField] private float _speed;
    [SerializeField] private float _checkTargetDistance; //플레이어를 체크하는 거리
    [SerializeField] private float _attackTargetDistance; // 플레이어를 공격하는 거리
    [SerializeField] private LayerMask _targetLayer;

    private Animator _animator;
    private Transform _targetObject;
    private Rigidbody2D _rigid;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rigid = GetComponent<Rigidbody2D>();
        SetHp(_hp);
        SetDmg(_dmg);
        SetSpeed(_speed);
    }
    private void Update()
    {
        CheckTarget();
    }

    protected override void CheckTarget()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, new Vector2(_checkTargetDistance, _checkTargetDistance), 0, _targetLayer);

        if (hit != null)
        {
            _targetObject = hit.transform;
            if (_attackTargetDistance < Vector2.Distance(transform.position, _targetObject.position))
                Attack();
            if (_checkTargetDistance < Vector2.Distance(transform.position, _targetObject.position))
                Move();
        }
        else
            _targetObject = null;
    }

    protected override void Idle()
    {
        _animator.SetTrigger("Idle");
        _animator.ResetTrigger("Move");
        _animator.ResetTrigger("Attack");

        CheckTarget();
    }
    protected override void Move()
    {
        _animator.SetTrigger("Move");
        _animator.ResetTrigger("Idle");
        _animator.ResetTrigger("Attack");
        
        _rigid.velocity = Vector3.MoveTowards(transform.position, _targetObject.transform.position, Speed * Time.deltaTime);

        CheckTarget();
    }
    protected override void Attack()
    {
        _animator.SetTrigger("Attack");
        _animator.ResetTrigger("Move");
        _animator.ResetTrigger("Idle");

        CheckTarget();
    }
    protected override void GetDamage()
    {
    }
    protected override void Run()
    {
    }

    private void OnDrawGizmos()
    {
        //attack
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector2(_attackTargetDistance, _attackTargetDistance));
        //check
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(_checkTargetDistance, _checkTargetDistance));
    }
}
