using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private float _startTime;
    private DateTime _date;
    public DateTime Date => _date;

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
    
    private void Init()
    {
        _startTime = Time.time;
    }
}
