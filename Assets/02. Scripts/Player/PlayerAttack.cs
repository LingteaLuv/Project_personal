using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Drag&Drop")]
    [SerializeField] private GameObject obj;

    private void Awake()
    {
        Init();
    }

    public void AtkUpdate(bool isAttack, IAttackable weapon)
    {
        if (isAttack)
        {
            weapon.Operate();
        }
    }
    
    
    private void Init()
    {
        
    }
}
