using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour, IAttackable
{
    public abstract void Operate();
}
