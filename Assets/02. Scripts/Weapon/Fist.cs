using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : BaseWeapon
{
    [Header("InputNumber")]
    [SerializeField] private int _atkDamage;

    private IDamageable _target;

    public override void Operate()
    {
        Debug.Log($"{_atkDamage}데미지 주먹질");
        if (_target != null)
        {
            _target.Damaged(_atkDamage); 
        }
        
    }

    public override void Activate()
    {
        
    }

    public override void Deactivate()
    {
        
    }

    public override void DisplayTrajectory()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Monster"))
        {
            Debug.Log("진입");
            _target = other.gameObject.GetComponent<IDamageable>();
        }
    }
}
