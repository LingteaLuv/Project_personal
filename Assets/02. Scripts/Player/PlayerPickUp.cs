using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [Header("InputNumber")]
    [SerializeField][Range(0,3)] private float _configRange;
    
    private List<GameObject> _targets;
    private GameObject _closeTarget;
    private bool _canPickUp;
    public bool CanPickUp => _canPickUp;
    
    private void Awake()
    {
        Init();
    }

    public void PickUp(PlayerInventory inventory)
    {
        if (_closeTarget != null)
        {
            inventory.AddStuff(_closeTarget.GetComponentInParent<LootingStuff>().Stuff);
            _targets.Remove(_closeTarget);
            Destroy(_closeTarget.transform.root.gameObject);
        }
    }

    public void ConfigItem()
    {
        float minDistance = float.MaxValue;

        foreach (var stuff in _targets)
        {
            float distance = Vector3.Distance(stuff.transform.position, transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                _closeTarget = stuff;
            }
        }
        
        if(_closeTarget != null)
        {
            Debug.Log(_closeTarget.name);
            Vector3 origin = transform.position;
            Vector3 target = _closeTarget.transform.position;
            Vector3 direction = (target - origin).normalized;
            
            _canPickUp = false;
            if (Physics.SphereCast(origin, 0.3f, direction, out RaycastHit hit, _configRange))
            {
                if (hit.transform.CompareTag("Stuff"))
                {
                    _canPickUp = true;
                }
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("추가전");
        if (other.transform.CompareTag("Stuff"))
        {
            Debug.Log("추가");
            _targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Stuff"))
        {
            Debug.Log("제거");
            _targets.Remove(other.gameObject);
        }
    }
    
    private void Init()
    {
        _targets = new List<GameObject>();
    }
}
