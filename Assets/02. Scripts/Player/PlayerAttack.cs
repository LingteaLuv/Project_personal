using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void Awake()
    {
        Init();
    }
    
    public void AtkUpdate(bool isAttack, IAttackable weapon)
    {
        weapon.DisplayTrajectory();
        if (isAttack)
        {
            weapon.Operate();
        }
    }
    
    
    private void Init()
    {
        
    }
}
