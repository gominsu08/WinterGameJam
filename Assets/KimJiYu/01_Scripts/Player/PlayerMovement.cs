using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [field: SerializeField] public InputReader inputReader { get; private set; }

    public float _moveSpeed;

    private Rigidbody2D _rigid;
    private Animator _anim;

    private Vector2 _moveDir;

    private void Awake()
    {
        inputReader.OnMove += GetMoveValue;

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
        if (!WeaponThrow.Instance.isPickUp)
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
