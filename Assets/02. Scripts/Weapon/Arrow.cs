using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Header("InputNumber")] 
    [SerializeField] private int _atkDamage;
    
    private Rigidbody _rigid;
    private bool _isUsed;
    
    public event Action OnArrowDestroyed;
    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        _rigid.isKinematic = true;
    }

    private void Update()
    {
        if (_rigid.velocity.magnitude > 0)
        {
            transform.forward = _rigid.velocity.normalized;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Wall") && !_isUsed)
        {
            _isUsed = true;
            OnArrowDestroyed?.Invoke();
            Destroy(gameObject);
        }

        if (other.transform.CompareTag("Monster") && !_isUsed)
        {
            _isUsed = true;
            other.transform.GetComponent<IDamageable>().Damaged(_atkDamage);
            OnArrowDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }

    private void Init()
    {
        _rigid = GetComponent<Rigidbody>();
        _isUsed = false;
    }
}
