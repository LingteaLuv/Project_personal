using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    public void Operate();
    public void Activate();
    public void Deactivate();
    public void DisplayTrajectory();
}
