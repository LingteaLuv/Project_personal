using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Grenade : BaseWeapon
{
    [Header("Drag&Drop")]
    [SerializeField] private GameObject _grenadePrefab;
    
    [Header("InputNumber")]
    [SerializeField] private float _speed;

    private LineRenderer _renderer;
    private Trajectory _trajectory;
    private GameObject _grenade;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        if (_grenade == null)
        {
            _grenade = Instantiate(_grenadePrefab, transform.position, Quaternion.Euler(transform.forward), transform);
            _grenade.GetComponent<Rigidbody>().isKinematic = true;
        }

        _renderer.enabled = true;
    }
    
    public override void Operate()
    {
        if (_grenade != null)
        {
            _renderer.enabled = false;
            _grenade.transform.SetParent(null);
            _grenade.GetComponent<Rigidbody>().isKinematic = false;
            _grenade.GetComponent<Rigidbody>().velocity = transform.forward * _speed;
        }
    }

    public override void Activate()
    {
        gameObject.SetActive(true);
    }

    public override void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public override void DisplayTrajectory()
    {
        if (_grenade == null) return;
        _trajectory.UpdateTrajectory(_grenade, _speed);
    }

    private void Init()
    {
        _renderer = GetComponent<LineRenderer>();
        _trajectory = GetComponent<Trajectory>();
    }
}
