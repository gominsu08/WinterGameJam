using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public InputReader inputReader { get; private set; }

    public float _moveSpeed;

    private bool _isDie;

    private Health _health;
    private Rigidbody2D _rigid;
    private Animator _anim;

    private Vector2 _moveDir;

    private void Awake()
    {
        _health = GameObject.Find("HP").GetComponent<Health>();
        inputReader.OnMove += GetMoveValue;

        _health.OnDeath += Die;
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
    }

    private void GetMoveValue(Vector2 dir)
    {
        _moveDir = dir;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Flip();
    }

    private void Move()
    {
        if (!WeaponThrow.Instance.isPickUp && !_isDie)
        {
            CheckAnim();
            _rigid.velocity = _moveDir.normalized * _moveSpeed;
        }
        else
        {
            _rigid.velocity = Vector2.zero;
        }
    }

    private void Flip()
    {
        if (_rigid.velocity.x < 0)
            transform.localScale = new Vector3(-1,1,1);
        else if (_rigid.velocity.x > 0)
            transform.localScale = Vector3.one;
    }

    private void Die()
    {
        _isDie = true;
        _anim.SetBool("Run", false);
        _anim.SetBool("Idle", false);
        _anim.SetBool("Die", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enenmy"))
        {
            if(collision.gameObject.TryGetComponent(out Monster monster))
            {
                
            }
        }
    }

    private void CheckAnim()
    {
        if (_moveDir == Vector2.zero)
            _anim.SetBool("Run", false);
        else
            _anim.SetBool("Run", true);
    }

    private void OnDisable()
    {
        inputReader.OnMove -= GetMoveValue;
    }
}
