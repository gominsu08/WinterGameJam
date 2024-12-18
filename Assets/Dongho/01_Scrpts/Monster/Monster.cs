using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    private float _hp;
    private float _dmg;
    private float _speed;

    protected float Hp {
        get
        {
            return _hp;
        }
        private set
        {
            _hp = value;
        }
    }
    protected float Dmg
    {
        get
        {
            return _dmg;
        }
        private set
        {
            _dmg = value;
        }
    }
    protected float Speed
    {
        get
        {
            return _speed;
        }
        private set
        {
            _speed = value;
        }
    }

    protected abstract void Attack();
    protected abstract void Idle();
    protected abstract void Move();
    protected abstract void GetDamage();
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
