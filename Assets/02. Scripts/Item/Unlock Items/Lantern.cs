using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    private Light _headlight;
    private bool _isTurnOn;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        if (ItemManager.Instance.HasLantern)
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
        if (Input.GetKeyDown(KeyCode.T))
        {
            _isTurnOn = !_isTurnOn;
            if (_isTurnOn != _headlight.gameObject.activeSelf)
            {
                _headlight.gameObject.SetActive(_isTurnOn);
            }
        }
    }
    
    private void Init()
    {
        _headlight = GetComponentInChildren<Light>();
        _isTurnOn = true;
    }
}
