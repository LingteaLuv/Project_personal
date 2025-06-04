using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private float _hitCooldown;
    private bool _isAttacked;

    public event Action OnAttacked;

    private void Awake()
    {
        Init();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Monster")&& !_isAttacked)
        {
            Debug.Log("진입1");
            StartCoroutine(HitRoutine());
        }
    }

    private IEnumerator HitRoutine()
    {
        _isAttacked = true;
        OnAttacked?.Invoke();
        yield return new WaitForSeconds(_hitCooldown);
        _isAttacked = false;
    }
    
    private void Init()
    {
        _hitCooldown = 1.5f;
        _isAttacked = false;
    }
}
