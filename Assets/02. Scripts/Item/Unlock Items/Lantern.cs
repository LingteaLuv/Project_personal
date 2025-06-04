using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    private Light _headlight;
    private bool _isTurnOn;

    private Camera _playerCam;
    private bool _isHasLight;
    
    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        _isHasLight = ItemManager.Instance.HasLantern;
        if (_isHasLight)
        {
            _headlight.gameObject.SetActive(true);
        }
        else
        {
            _headlight.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && _isHasLight)
        {
            _isTurnOn = !_isTurnOn;
            if (_isTurnOn != _headlight.gameObject.activeSelf)
            {
                _headlight.gameObject.SetActive(_isTurnOn);
            }
        }

        RotationUpdate();
    }

    private void RotationUpdate()
    {
        Vector3 curRot = transform.rotation.eulerAngles;
        curRot.x = _playerCam.transform.rotation.eulerAngles.x;
        transform.rotation = Quaternion.Euler(curRot);
    }
    
    private void Init()
    {
        _headlight = GetComponentInChildren<Light>();
        _isTurnOn = true;
        _playerCam = transform.root.GetComponentInChildren<Camera>();
    }
}
