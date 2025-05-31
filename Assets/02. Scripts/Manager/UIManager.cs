using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject _curUI;

    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    public void OpenUI(GameObject curUI)
    {
        if (curUI != null)
        {
            _curUI = curUI;
            // todo : 상호작용 한 UI 창 켜기(활성화) 
        }
    }

    public void CloseUI()
    {
        // todo : 상호작용 한 UI 창 끄기(비활성화)
        _curUI = null;
    }
    
    private void Init()
    {
        
    }
}
