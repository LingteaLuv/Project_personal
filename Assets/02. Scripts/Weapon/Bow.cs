using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Bow : BaseWeapon
{
    [Header("Drag&Drop")]
    [SerializeField] private GameObject _arrowPrefab;
    [SerializeField] private LineRenderer _renderer;
    
    [Header("InputNumber")]
    [SerializeField] private float _arrowSpeed;

    private GameObject _curArrow;
    private Camera _camera;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        if (_curArrow == null)
        {
            _curArrow = Instantiate(_arrowPrefab, transform.position, Quaternion.Euler(transform.forward), transform);
        }
        else
        {
            _curArrow.SetActive(true);
        }

        _curArrow.GetComponent<Arrow>().OnArrowDestroyed += () =>
        {
            CreateNewArrow();
            _renderer.enabled = true;
        };
    }

    private void OnDisable()
    {
        if (_curArrow != null)
        {
            _curArrow.SetActive(false);
        }
        _curArrow.GetComponent<Arrow>().OnArrowDestroyed -= () =>
        {
            CreateNewArrow();
            _renderer.enabled = true;
        };
    }

    public override void DisplayTrajectory()
    {
        int pointCount = 30;
        float deltaTime = 0.1f;

        Vector3[] trajectorys = new Vector3[pointCount];
        Vector3 startPos = transform.position;

        transform.rotation = Quaternion.Euler(_camera.transform.eulerAngles.x, _camera.transform.eulerAngles.y, 0);
        
        _curArrow.transform.rotation = transform.rotation;
        
        float speed = _arrowSpeed;
        Vector3 startVel = transform.forward * speed;

        for (int i = 0; i < pointCount; i++)
        {
            trajectorys[i] = CalculatePoint(startPos, startVel, deltaTime * i);
        }

        _renderer.positionCount = pointCount;
        _renderer.SetPositions(trajectorys);
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
        gameObject.SetActive(true);
    }

    public override void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void Init()
    {
        _renderer = GetComponentInChildren<LineRenderer>();
        _camera = transform.parent.GetComponentInChildren<Camera>();
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
    

    private Vector3 CalculatePoint(Vector3 startPos, Vector3 startVel, float time)
    {
        Vector3 gravity = Physics.gravity;
        return startPos + startVel * time + 0.5f * gravity * time * time;
    }
}
