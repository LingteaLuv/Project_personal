using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : MonoBehaviour, IPlayerStatHandler, IDetectRangeNotify, ISpeedNotify
{
    
    public Property<int> Hp;
    public Property<float> Mentality;
    public Property<float> MentalityDecrease;
    public Property<float> Hunger;
    [SerializeField] private float _detectRange;

    private float _mentalTimer;
    private float _hpTimer;
    
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
        HudManager.Instance.Subscribe(this);
    }
    
    private void Update()
    {
        DecreaseMentality(GameManager.Instance.IsInMaze);
        DecreaseHp();
        DecreaseHenger();
    }
    
    private void DecreaseMentality(bool isInMaze)
    {
        if (isInMaze)
        {
            _mentalTimer += Time.deltaTime;
            if (_mentalTimer > 1f)
            {
                Mentality.Value -= MentalityDecrease.Value;
                _mentalTimer = 0f;
            }
        }
    }

    private void DecreaseHp()
    {
        if (Mentality.Value <= 0)
        {
            _hpTimer += Time.deltaTime;
            if (_hpTimer > 1f)
            {
                Hp.Value -= 1;
                _hpTimer = 0f;
            }
        }
    }

    private void DecreaseHenger()
    {
        Hunger.Value -= 100 * (GameManager.Instance.FlowTime / 84 * 60 * 60);
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
            MentalityDecrease.Value += mod.MentalityDecreaseChange;
            _detectRange += mod.DetectRangeChange;
            _speed += mod.SpeedChange;
        }
    }
    
    private void Init()
    {
        _activeModifiers = new List<StatModifier>();
        _mentalTimer = 0;
        _hpTimer = 0;
        Hp = new Property<int>(100);
        Mentality = new Property<float>(100);
        Hunger = new Property<float>(100);
        MentalityDecrease = new Property<float>(1);
    }
}
