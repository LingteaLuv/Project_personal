using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // todo : 포탈 UI OnClick에 연동, 게임 클리어 -> 씬 매니저 - 씬 전환
    }
    
    private void Init()
    {
        
    }
}
