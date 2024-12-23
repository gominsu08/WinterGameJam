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
    public float Dmg
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

    protected abstract void Dead();
    protected abstract void Idle();
    protected abstract void Move();
    public abstract void GetDamage(float damage);
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
