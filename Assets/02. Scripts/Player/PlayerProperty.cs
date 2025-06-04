using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProperty : MonoBehaviour, IPlayerStatHandler
{
    public Property<int> Hp;
    public Property<float> Mentality;
    public Property<float> MentalityDecrease;
    public Property<float> MentalityIncrease;
    public Property<float> Hunger;
    public Property<float> Speed;
    public Property<float> DetectRange;

    private float _mentalTimer;
    private float _hpTimer;
    private bool _curState;
    
    private List<StatModifier> _activeModifiers;
    
    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        HudManager.Instance.Subscribe(this);
        UIBinder.Instance.Mediate(this);
    }
    
    private void Update()
    {
        ChangeMentality(GameManager.Instance.IsInMaze);
        ChangeHp(GameManager.Instance.IsInMaze);
        DecreaseHunger();
    }

    public void HideUpdate(bool isHide)
    {
        if (_curState != isHide)
        {
            Speed.Value = isHide ? 2f : 5f;
            DetectRange.Value = isHide ? 1.5f : 5f;
            _curState = isHide;
        }
    }

    public void Hit()
    {
        Debug.Log("진입3");
        Hp.Value -= 10;
        Debug.Log(Hp.Value);
        if (Hp.Value <= 0)
        {
            Hp.Value = 0;
            GameManager.Instance.GameOver();
        }
    }
    
    private void ChangeMentality(bool isInMaze)
    {
        if (isInMaze)
        {
            if (Mentality.Value > 0)
            {
                _mentalTimer += Time.deltaTime;
                if (_mentalTimer > 1f)
                {
                    Mentality.Value -= MentalityDecrease.Value;
                    _mentalTimer = 0f;
                }
            }
            else
            {
                Mentality.Value = 0;
            }
        }

        if (!isInMaze)
        {
            if (Mentality.Value < 100)
            {
                _mentalTimer += Time.deltaTime;
                if (_mentalTimer > 1f)
                {
                    Mentality.Value += MentalityIncrease.Value;
                    _mentalTimer = 0f;
                }
            }
            else
            {
                Mentality.Value = 100;
            }
        }
    }

    private void ChangeHp(bool isInMaze)
    {
        if (Mentality.Value <= 0 && isInMaze)
        {
            _hpTimer += Time.deltaTime;
            if (_hpTimer > 1f)
            {
                if (Hp.Value <= 0)
                {
                    Hp.Value = 0;
                    GameManager.Instance.GameOver();
                }
                Hp.Value -= 1;
                _hpTimer = 0f;
            }
        }

        if (!isInMaze)
        {
            if (Hp.Value < 100)
            {
                _hpTimer += Time.deltaTime;
                if (_hpTimer > 2f)
                {
                    Hp.Value += 1;
                    _hpTimer = 0f;
                }
            }
            else
            {
                Hp.Value = 100;
            }
        }
    }

    private void DecreaseHunger()
    {
        Hunger.Value = 100 * (1 - GameManager.Instance.FlowTime / (84 * 60 * 60));
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
            DetectRange.Value += mod.DetectRangeChange;
            Speed.Value += mod.SpeedChange;
        }
    }
    
    private void Init()
    {
        _activeModifiers = new List<StatModifier>();
        _mentalTimer = 0;
        _hpTimer = 0;
        Hp = new Property<int>(100);
        Mentality = new Property<float>(100f);
        Hunger = new Property<float>(100f);
        MentalityDecrease = new Property<float>(1f);
        MentalityIncrease = new Property<float>(3f);
        Speed = new Property<float>(5f);
        DetectRange = new Property<float>(5f);
    }
}
