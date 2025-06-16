using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [Header("Drag&Drop")]
    [SerializeField] private ObjectGenerator _generator;

    private float _offset;
    
    private float _startTime;
    private DateTime _date;
    public DateTime Date => _date;

    private float _flowTime;

    private float _hungerTime;
    public float HungerTime => _hungerTime;

    private int _monsterEssence;

    private bool _isPortalGenerated;
    public bool IsPortalGenerated => _isPortalGenerated;

    public bool IsInMaze;

    public Property<bool> IsPaused;

    private float _curTime;

    public bool IsInteracted;

    protected override void Awake()
    {
        base.Awake();
        IsPaused = new Property<bool>(false);
        Init();
        DontDestroyOnLoad(gameObject);
    }
    
    private void Start()
    {
        SceneManager.sceneLoaded += ResetField;
    }
    
    private void Update()
    {
        if (!IsPaused.Value && !IsInteracted)
        {
            _curTime = Time.time;
            _flowTime = (_curTime - _startTime);
            _hungerTime = _flowTime * _offset;
            _date = CalculateDate();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                IsPaused.Value = true;
                Time.timeScale = 0;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !IsInteracted)
            {
                ContinueMethod();
            } 
        }
    }
    
    public void ResetField(Scene scene, LoadSceneMode mode)
    {
        Init();
    }

    public void ContinueMethod()
    {
        IsPaused.Value = false;
        Time.timeScale = 1;
    }

    private DateTime CalculateDate()
    {
        DateTime temp = new DateTime();
        
        temp.Second = (int)(_flowTime * _offset) % 60;
        temp.Minute = (int)(_flowTime * _offset / 60) % 60;
        temp.Hour = (9 + (int)((_flowTime * _offset / 60) / 60)) % 24;
        temp.Day = 1 + (9 + (int)(_flowTime * _offset / 60 / 60)) / 24;
        return temp;
    }

    public void GameStart()
    {
        IsPaused.Value = false;
        SceneManager.LoadScene("InGame", LoadSceneMode.Single);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }

    public void GameExit()
    {
        SceneManager.LoadScene("Title");
    }
    
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void GameClear()
    {
        SceneManager.LoadScene("GameClear");
    }

    public void KillMonster()
    {
        _monsterEssence++;
        if (_monsterEssence > 3)
        {
            CreatePortal();
        }
    }

    private void CreatePortal()
    {
        _generator.GeneratePortal();
        _isPortalGenerated = true;
        TextManager.Instance.PopupTextForSecond("popup_006", 2f);
    }
    
    private void Init()
    {
        _startTime = Time.time;
        Time.timeScale = 1;
        _monsterEssence = 0;
        _isPortalGenerated = false;
        IsInMaze = false;
        IsPaused.Value = false;
        _offset = 120;
    }
}
