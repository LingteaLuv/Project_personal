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
        Debug.Log($"PickUp 호출, _canPickUp={_canPickUp}, _closeTarget={_closeTarget}");
        if (_closeTarget != null)
        {
            inventory.AddStuff(_closeTarget.GetComponent<Stuff>());
            Debug.Log($"인벤에 추가 : {_closeTarget.name}");
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
            Vector3 origin = transform.position;
            Vector3 target = _closeTarget.transform.position;
            Vector3 direction = (target - origin).normalized;
            
            Debug.DrawRay(origin,direction,Color.red,_configRange);
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
        if (other.transform.CompareTag("Stuff"))
        {
            _targets.Add(other.gameObject);
            Debug.Log("진입1");
            Debug.Log(_targets);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Stuff"))
        {
            _targets.Remove(other.gameObject);
        }
    }
    
    private void Init()
    {
        _targets = new List<GameObject>();
    }
}
