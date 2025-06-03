using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class StatUI : MonoBehaviour
{
    private GameObject _statInterface;
    private bool _isOpened;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!_isOpened)
            {
                UIManager.Instance.OpenUI(_statInterface);
                GameManager.Instance.IsInteracted = true;
                _isOpened = true;
            }
            else
            {
                UIManager.Instance.CloseUI();
                GameManager.Instance.IsInteracted = false;
                _isOpened = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isOpened)
            {
                UIManager.Instance.CloseUI();
                GameManager.Instance.IsInteracted = false;
                _isOpened = false;
            }
        }
    }

    private void Init()
    {
        _statInterface = transform.GetChild(0).gameObject;
        _statInterface.SetActive(false);
    }
}
