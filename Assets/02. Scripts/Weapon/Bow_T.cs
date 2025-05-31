using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow_T : BaseWeapon
{
    [Header("Drag&Drop")]
    [SerializeField] private GameObject _arrowPrefab;
    
    [Header("InputNumber")]
    [SerializeField] private float _arrowSpeed;

    private LineRenderer _renderer;
    private Trajectory _trajectory;
    private GameObject _curArrow;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        if (_curArrow == null)
        {
            _curArrow = Instantiate(_arrowPrefab, transform.position, Quaternion.Euler(transform.forward), transform);
            _curArrow.GetComponent<Arrow>().OnArrowDestroyed += CreateNewArrow;
            _curArrow.SetActive(false);
        }
        _curArrow.transform.rotation = transform.rotation;
        _renderer.enabled = true;
    }
    
    public override void Operate()
    {
        if (_curArrow != null)
        {
            _renderer.enabled = false;
            _curArrow.transform.SetParent(null);
            _curArrow.GetComponent<Rigidbody>().isKinematic = false;
            _curArrow.GetComponent<Rigidbody>().velocity = transform.forward * _arrowSpeed;
        }
    }

    public override void Activate()
    {
        _curArrow.SetActive(true);
        _renderer.enabled = true;
    }

    public override void Deactivate()
    {
        _curArrow.SetActive(false);
        _renderer.enabled = false;
    }

    public override void DisplayTrajectory()
    {
        _trajectory.UpdateTrajectory(_curArrow, _arrowSpeed);
    }

    private void Init()
    {
        _renderer = GetComponent<LineRenderer>();
        _trajectory = GetComponent<Trajectory>();
    }

    private void CreateNewArrow()
    {
        _curArrow = Instantiate(_arrowPrefab, transform.position, Quaternion.Euler(transform.forward), transform);
        Arrow arrowScript = _curArrow.GetComponent<Arrow>();
        arrowScript.OnArrowDestroyed += () =>
        {
            CreateNewArrow();  
            _renderer.enabled = true;
        };
        _renderer.enabled = true;
    }
}
