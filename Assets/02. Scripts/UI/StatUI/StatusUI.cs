using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusUI : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private TMP_Text _hpText;
    [SerializeField] private TMP_Text _mentalityText;
    [SerializeField] private TMP_Text _hungerText;
    [SerializeField] private TMP_Text _speedText;
    [SerializeField] private TMP_Text _stealthText;
    
    private PlayerProperty _playerProperty;
    private bool _isOpen;
    
    
    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        if (_isOpen)
        {
            _hpText.text = $"   HP : {_playerProperty.Hp.Value}";
            _mentalityText.text = $"   Mentality : {_playerProperty.Mentality.Value}";
            _hungerText.text = $"   Hunger : {(int)_playerProperty.Hunger.Value}";
            _speedText.text = $"   Speed : {_playerProperty.Speed.Value}";
            _stealthText.text = $"   StealthRange : {_playerProperty.DetectRange.Value}";
        }
    }
    
    private void OnEnable()
    {
        _isOpen = true;
    }
    
    private void OnDisable()
    {
        _isOpen = false;
    }

    public void SetProperty(PlayerProperty property)
    {
        _playerProperty = property;
    }
    
    private void Init()
    {
        _isOpen = false;
    }
}
