using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour, IAttackable
{
    public abstract void Operate();

    public abstract void Activate();

    public abstract void Deactivate();

    public abstract void DisplayTrajectory();
}
