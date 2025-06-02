using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpUI : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private TMP_Text _popUpText;

    private void Awake()
    {
        Init();
    }

    public void PopupText(string text)
    {
        _popUpText.text = text;
    }
    
    private void Init()
    {
        if (_popUpText == null)
        {
            _popUpText = GetComponentInChildren<TMP_Text>();
        }
    }
}
