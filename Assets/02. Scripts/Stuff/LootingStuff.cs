using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootingStuff : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private Stuff _stuff;
    public Stuff Stuff => _stuff;
    
    [Header("InputNumber")] 
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
    }
}
