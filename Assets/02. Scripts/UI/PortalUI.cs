using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalUI : MonoBehaviour
{
    [Header("Drag&Drop")]
    [SerializeField] private Button _yesBtn;
    [SerializeField] private Button _noBtn;

    public event Action OnClickNoBtn;
    
    private void Start()
    {
        _yesBtn.onClick.AddListener(() => GameManager.Instance.GameClear());
        _noBtn.onClick.AddListener(() => OnClickNoBtn?.Invoke());
    }
}
