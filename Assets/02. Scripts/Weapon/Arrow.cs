using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody _rigid;

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
        if (other.transform.CompareTag("Wall"))
        {
            OnArrowDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }

    private void Init()
    {
        _rigid = GetComponent<Rigidbody>();
    }
}
