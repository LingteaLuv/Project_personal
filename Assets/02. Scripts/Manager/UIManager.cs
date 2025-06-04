using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject CurUI;

    private void Start()
    {
        GameManager.Instance.OnPauseChanged += GamePause;
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

    public void GamePause(bool isPaused)
    {
        CurUI = UIBinder.Instance.GetPauseUI().gameObject;
        CurUI.SetActive(isPaused);
        if (!isPaused)
        {
            CurUI = null;
        }
    }
}
