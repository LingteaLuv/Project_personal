using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject CurUI;
    
    protected override void Awake()
    {
        base.Awake();
        if (transform.parent == null)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        GameManager.Instance.IsPaused.OnChanged += GamePause;
        //GamePause(GameManager.Instance.IsPaused.Value);
    }
    
    
    public void OpenUI(GameObject curUI)
    {
        if (curUI != null)
        {
            CurUI = curUI;
            CurUI.gameObject.SetActive(true);
        }
    }

    public void CloseUI()
    {
        CurUI.gameObject.SetActive(false);
        CurUI = null;
    }
    
    private void GamePause(bool isPaused)
    {
        CurUI = UIBinder.Instance.GetPauseUI().gameObject;
        CurUI.SetActive(isPaused);
        if (!isPaused)
        {
            CurUI = null;
        }
    }
}
