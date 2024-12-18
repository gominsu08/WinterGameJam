using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    protected Animator _animator;

    private float hp;
    private float dmg;
    private float speed;

    protected float Hp {
        get
        {
            return hp;
        }
        private set
        {
            hp = value;
        }
    }
    protected float Dmg
    {
        get
        {
            return dmg;
        }
        private set
        {
            dmg = value;
        }
    }
    protected float Speed
    {
        get
        {
            return speed;
        }
        private set
        {
            speed = value;
        }
    }

    protected virtual void Attack()
    {
        _animator.SetTrigger("Attack");
        _animator.ResetTrigger("Move");
        _animator.ResetTrigger("Idle");
        _animator.ResetTrigger("Hit");
    }
    protected virtual void Idle()
    {
        _animator.SetTrigger("Idle");
        _animator.ResetTrigger("Move");
        _animator.ResetTrigger("Attack");
        _animator.ResetTrigger("Hit");
    }
    protected virtual void Move()
    {
        _animator.SetTrigger("Move");
        _animator.ResetTrigger("Idle");
        _animator.ResetTrigger("Attack");
        _animator.ResetTrigger("Hit");
    }
    protected virtual void GetDamage()
    {
        _animator.ResetTrigger("Attack");
        _animator.ResetTrigger("Move");
        _animator.SetTrigger("Hit");
        _animator.ResetTrigger("Idle");
    }
    protected abstract void Run();
    protected abstract void CheckTarget();

    protected virtual void SetHp(float hp)
    {
        Hp = hp;
    }
    protected virtual void SetDmg(float dmg)
    {
        Dmg = dmg;
    }
    protected virtual void SetSpeed(float speed)
    {
        Speed = speed;
    }
}
