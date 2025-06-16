using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bow_T : BaseWeapon
{
    [Header("Drag&Drop")]
    [SerializeField] private GameObject _arrowPrefab;
    
    [Header("InputNumber")]
    [SerializeField] private float _arrowSpeed;
    [SerializeField] private int _arrowCount;

    private LineRenderer _renderer;
    private Trajectory _trajectory;
    private GameObject _curArrow;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        TransferManager.Instance.OnArrowAdded += CreateNewQuiver;
    }
    
    private void OnEnable()
    {
        if (_curArrow == null  && _arrowCount > 0)
        {
            _curArrow = Instantiate(_arrowPrefab, transform.position, Quaternion.Euler(transform.forward), transform);
            _curArrow.GetComponent<Arrow>().OnArrowDestroyed += CreateNewArrow;
            _curArrow.SetActive(false);
            _arrowCount--;
        }
        if (_curArrow != null)
        {
            _curArrow.transform.rotation = transform.rotation;
            _renderer.enabled = true;
        }
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
        if (_curArrow != null)
        {
            _curArrow.SetActive(true);
            _renderer.enabled = true;
        }
       
    }

    public override void Deactivate()
    {
        if (_curArrow != null)
        {
            _curArrow.SetActive(false);
        }
        _renderer.enabled = false;
    }

    public override void DisplayTrajectory()
    {
        if (_curArrow != null)
        {
            _trajectory.UpdateTrajectory(_curArrow, _arrowSpeed);
        }
    }

    private void Init()
    {
        _renderer = GetComponent<LineRenderer>();
        _trajectory = GetComponent<Trajectory>();
        
        _arrowCount = 3;
    }

    private void CreateNewQuiver()
    {
        _arrowCount += 10;
        CreateNewArrow();
    }
    
    private void CreateNewArrow()
    {
        if (_arrowCount > 0)
        {
            _curArrow = Instantiate(_arrowPrefab, transform.position, Quaternion.Euler(transform.forward), transform);
            _arrowCount--;
            Arrow arrowScript = _curArrow.GetComponent<Arrow>();
            arrowScript.OnArrowDestroyed += () =>
            {
                CreateNewArrow();  
            };
            _renderer.enabled = true;
        }
        else
        {
            TextManager.Instance.PopupTextForSecond("popup_007", 2f);
        }
    }
}
