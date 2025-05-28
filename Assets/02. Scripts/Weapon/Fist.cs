using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : BaseWeapon
{
    [Header("InputNumber")]
    [SerializeField] private int _atkDamage;

    public override void Operate()
    {
        Debug.Log($"{_atkDamage}데미지 주먹질");
    }
}
