using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TextManager : Singleton<TextManager>
{
    private PopUpUI _popUpUI;
    private TextLoader _textLoader;
    
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        Init();
    }

    private void Start()
    {
        ConfigUI();
    }

    private void Init()
    {
        _textLoader = transform.GetOrAddComponent<TextLoader>();
    }

    private void ConfigUI()
    {
        if (_popUpUI == null)
        {
            _popUpUI = UIBinder.Instance.GetPopUpUI();
        }
    }
    
    private void PopupText(string id)
    {
        ConfigUI();
        string popupText = _textLoader.GetPopupText(id);
        _popUpUI.gameObject.SetActive(true);
        _popUpUI.PopupText(popupText);
    }

    public void PopupTextForSecond(string id, float time)
    {
        StartCoroutine(PopupTextRoutine(id, time));
    }

    private IEnumerator PopupTextRoutine(string id, float time)
    {
        PopupText(id);
        yield return new WaitForSeconds(time);
        HideText();
    }
    
    private void HideText()
    {
        _popUpUI.ResetText();
        _popUpUI.gameObject.SetActive(false);
    }
}
