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
    public float FlowTime => _flowTime;

    private int _monsterEssence;

    private bool _isPortalGenerated;
    public bool IsPortalGenerated => _isPortalGenerated;

    public bool IsInMaze;

    private bool _isPaused;

    private float _curTime;

    private void Start()
    {
        Init();
    }
    
    private void Update()
    {
        if (!_isPaused)
        {
            _curTime = Time.time;
            _flowTime = (_curTime - _startTime);
            _date = CalculateDate();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _isPaused = true;
                Time.timeScale = 0;
                UIManager.Instance.GamePause();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ContinueMethod();
            } 
        }
    }

    public void ContinueMethod()
    {
        _isPaused = false;
        Time.timeScale = 1;
        UIManager.Instance.CloseUI();
    }

    private DateTime CalculateDate()
    {
        DateTime temp = new DateTime();
        
        temp.Second = (int)(_flowTime * _offset) % 60;
        temp.Minute = (int)(_flowTime * _offset / 60) % 60;
        temp.Hour = 9 + (int)(_flowTime * _offset / 60) / 60 % 24;
        temp.Day = 1 + (int)(_flowTime * _offset / 60) / 60 / 24;
        return temp;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
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
    }
    
    private void Init()
    {
        _startTime = Time.time;
        Time.timeScale = 1;
        _monsterEssence = 0;
        _isPortalGenerated = false;
        IsInMaze = false;
        _isPaused = false;
        _offset = 120;
    }
}
