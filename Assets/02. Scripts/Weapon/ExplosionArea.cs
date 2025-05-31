using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class ExplosionArea : MonoBehaviour
{
    [Header("InputNumber")]
    [SerializeField][Range(10,50)] private int _atkdamage;
    [SerializeField][Range(0,1)] private float _lifeTime;

    private bool _isUsed;

    private void Awake()
    {
        Init();
    }
    
    private void OnEnable()
    {
        Invoke(nameof(DestroySelf), _lifeTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Monster") && !_isUsed)
        {
            _isUsed = true;
            other.transform.GetComponent<IDamageable>().Damaged(_atkdamage);
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void Init()
    {
        _isUsed = false;
    }
}
