using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public Stack<GameObject> CurUI;
    
    protected override void Awake()
    {
        base.Awake();
        if (transform.parent == null)
        {
            DontDestroyOnLoad(gameObject);
        }

        Init();
    }

    private void Start()
    {
        GameManager.Instance.IsPaused.OnChanged += GamePause;
    }
    
    public void OpenUI(GameObject curUI)
    {
        if (curUI != null)
        {
            CurUI.Push(curUI);
            CurUI.Peek().gameObject.SetActive(true);
        }
    }

    public void CloseUI()
    {
        CurUI.Pop().SetActive(false);
    }
    
    private void GamePause(bool isPaused)
    {
        if (UIBinder.Instance.GetPauseUI() == null) return;
        CurUI.Push(UIBinder.Instance.GetPauseUI().gameObject);
        CurUI.Pop().SetActive(isPaused);
    }

    private void Init()
    {
        CurUI = new Stack<GameObject>();
    }
}
