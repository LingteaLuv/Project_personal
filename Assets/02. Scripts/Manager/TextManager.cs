using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : Singleton<TextManager>
{
    private GameObject _popUpUI;
    private TextLoader _textLoader;
    
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        Init();
    }

    private void Update()
    {
        
    }

    private void Init()
    {
        _textLoader = GetComponent<TextLoader>();
    }
    
    public void Refer(GameObject popupUI)
    {
        _popUpUI = popupUI;
        _popUpUI.SetActive(false);
    }
    
    public void PopupText(string id)
    {
        string popupText = _textLoader.GetPopupText(id);
        _popUpUI.gameObject.SetActive(true);
        _popUpUI.GetComponent<PopUpUI>().PopupText(popupText);
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
    
    public void HideText()
    {
        _popUpUI.SetActive(false);
    }
}
