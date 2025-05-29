using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    [Header("Drag&Drop")]
    [SerializeField] private ExplosionArea _explosionAreaPrefab;
    
    public event Action OnExplode;

    /*private void Start()
    {
        OnExplode += () =>
        {
            var explosionArea = Instantiate(_explosionAreaPrefab, transform.position, quaternion.identity);
        };
    }*/
    private void OnCollisionEnter(Collision other)
    {
        if (_explosionAreaPrefab != null)
        {
            Instantiate(_explosionAreaPrefab, transform.position, Quaternion.identity);
        }
        OnExplode?.Invoke();
        Destroy(gameObject);
    }
}
