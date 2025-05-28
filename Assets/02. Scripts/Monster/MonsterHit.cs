using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHit : MonoBehaviour,IDamageable
{
    [Header("InputNumber")]
    [SerializeField] private int _maxHp;

    private int _curHp;
    private bool _isDead;
    public bool IsDead => _isDead;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _curHp = _maxHp;
    }

    public void Damaged(int atkDamage)
    {
        _curHp -= atkDamage;
        Debug.Log(_curHp);
        if (_curHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _isDead = true;
        Destroy(transform.root.gameObject);
    }
}
