using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : MonoBehaviour, IPlayerStatHandler, IDetectRangeNotify, ISpeedNotify
{
    [Header("InputNumber")]
    [SerializeField] private int _hp;
    [SerializeField] private int _mentality;
    [SerializeField] private float _mentalityDecrease;
    [SerializeField] private int _hunger;
    [SerializeField] private float _detectRange;
    public float DetectRange
    {
        get { return _detectRange; }
        set
        {
            _detectRange = value;
            OnDetectRangeChanged?.Invoke(_detectRange);
        }
    }
    public event Action<float> OnDetectRangeChanged;

    [SerializeField] private float _speed;
    public float Speed
    {
        get { return _speed; }
        set
        {
            _speed = value;
            OnSpeedChanged?.Invoke(_speed);
        }
    }
    public event Action<float> OnSpeedChanged;

    private List<StatModifier> _activeModifiers;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        OnSpeedChanged?.Invoke(_speed);
    }
    
    public void ApplyModifier(StatModifier modifier)
    {
        _activeModifiers.Add(modifier);
        UpdateStat();
    }

    public void RemoveModifier(StatModifier modifier)
    {
        _activeModifiers.Remove(modifier);
        UpdateStat();
    }

    private void UpdateStat()
    {
        foreach (var mod in _activeModifiers)
        {
            _mentalityDecrease += mod.MentalityDecreaseChange;
            _detectRange += mod.DetectRangeChange;
            _speed += mod.SpeedChange;
        }
    }
    
    private void Init()
    {
        _activeModifiers = new List<StatModifier>();
    }
}
