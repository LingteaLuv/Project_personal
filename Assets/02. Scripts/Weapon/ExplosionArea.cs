using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class ExplosionArea : MonoBehaviour
{
    [Header("InputNumber")]
    [SerializeField][Range(10,50)] private int _damage;
    [SerializeField][Range(0,1)] private float _lifeTime;

    private void OnEnable()
    {
        Invoke(nameof(DestroySelf), _lifeTime);
        Debug.Log("진입2");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            other.GetComponent<IDamageable>().Damaged(_damage);
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
