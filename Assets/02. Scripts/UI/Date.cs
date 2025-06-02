using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.UI;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Date : MonoBehaviour
{
    private TMP_Text _dateText;
    private DateTime _curDate;

    
    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        _curDate = GameManager.Instance.Date;
        _dateText.text = $"Day{_curDate.Day} | {_curDate.Hour:D2}:{_curDate.Minute:D2}:{_curDate.Second:D2}";
    }

    private void Init()
    {
        _dateText = GetComponent<TextMeshProUGUI>();
    }
}
