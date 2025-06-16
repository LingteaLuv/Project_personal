using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    private float _hitCooldown;
    private bool _isAttacked;
    private int _atkDamage;

    private void Awake()
    {
        Init();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player")&& !_isAttacked)
        {
            other.transform.GetComponent<IDamageable>().Damaged(_atkDamage);
            StartCoroutine(HitRoutine());
        }
    }

    private IEnumerator HitRoutine()
    {
        _isAttacked = true;
        yield return new WaitForSeconds(_hitCooldown);
        _isAttacked = false;
    }
    
    private void Init()
    {
        _hitCooldown = 1.5f;
        _isAttacked = false;
        _atkDamage = 60;
    }
}
