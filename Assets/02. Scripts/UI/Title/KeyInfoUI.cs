using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyInfoUI : MonoBehaviour
{
    [Header("Drag&Drop")]
    [SerializeField] private Button _button;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        _button.onClick.AddListener(()=> gameObject.SetActive(false));
        gameObject.SetActive(false);
    }

    private void Init()
    {
        
    }
}
