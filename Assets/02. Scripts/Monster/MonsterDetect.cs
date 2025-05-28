using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDetect : MonoBehaviour
{
    [Header("Drag&Drop")]
    [SerializeField] private LayerMask _playerLayer;

    [Header("InputNumber")]
    [SerializeField] private float _firstDetectRange;
    [SerializeField][Range(5,10)] private float _secondDetectRange;
    
    private bool _isFirstDetect;
    public bool IsFirstDetect => _isFirstDetect;

    private bool _isSecondDetect;
    public bool IsSecondDetect => _isSecondDetect;

    private Transform _target;
    public Transform Target => _target;

    private void Awake()
    {
        Init();
    }

    public void Detect()
    {
        if (_target != null)
        {
            float distance = Vector3.Distance(transform.position, _target.position);
            float offset = _target.GetComponent<PlayerStealth>().Range;
            if (distance < _firstDetectRange + offset)
            {
                if (IsVisible(_target))
                {
                    _isFirstDetect = true;
                    _isSecondDetect = false;
                    if(distance < _secondDetectRange + offset)
                    {
                        _isFirstDetect = false;
                        _isSecondDetect = true;
                    }
                }
                else
                {
                    _isFirstDetect = false;
                    _isSecondDetect = false;
                }
            }
            else
            {
                _isFirstDetect = false;
                _isSecondDetect = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Presence"))
        {
            _target = other.transform;
            Debug.Log(_target);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Presence"))
        {
            _target = null;
            Debug.Log("범위 밖으로 나감");
        }
    }

    private bool IsVisible(Transform player)
    {
        Vector3 origin = transform.position;
        Vector3 target = player.position;

        Vector3 direction = (target - origin).normalized;
        float distance = Vector3.Distance(origin, target);

        if (Physics.Raycast(transform.position, direction, out RaycastHit hit, distance, _playerLayer))
        {
            if (hit.transform.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }
    
    private void Init()
    {
        _firstDetectRange = _secondDetectRange + 2f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, _firstDetectRange);
        
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position,_secondDetectRange);
    }
}
