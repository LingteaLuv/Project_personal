using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iron : Stuff
{
    [Header("InputNumber")] 
    [SerializeField] private float _rotateSpeed;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
    }

    private void Init()
    {
        
    }
}
