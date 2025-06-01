using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Drag&Drop")]
    [SerializeField] private ObjectGenerator _generator;
    
    private float _startTime;
    private DateTime _date;
    public DateTime Date => _date;

    private int _monsterEssence;

    private bool _isPortalGenerated;
    public bool IsPortalGenerated => _isPortalGenerated;

    private void Start()
    {
        Init();
    }
    
    private void Update()
    {
        _date = CalculateDate();
    }

    private DateTime CalculateDate()
    {
        DateTime temp = new DateTime();
        float flowTime = Time.time - _startTime;
        temp.Second = (int)flowTime % 60;
        temp.Minute = (int)(flowTime / 60) % 60;
        temp.Hour = (int)(flowTime / 60) / 60 % 24;
        temp.Day = (int)(flowTime / 60) / 60 / 24;
        return temp;
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
        _monsterEssence = 0;
        _isPortalGenerated = false;
    }
}
