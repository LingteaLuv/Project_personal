using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [Header("Drag&Drop")]
    [SerializeField] private GameObject _portalUI;

    private void Awake()
    {
        Init();
    }

    public void InteractPortal()
    {
        UIManager.Instance.OpenUI(_portalUI);
    }

    public void Escape()
    {
        GameManager.Instance.GameClear();
    }
    
    private void Init()
    {
        
    }
}
