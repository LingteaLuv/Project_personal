using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private Button _continueBtn;
    [SerializeField] private Button _newGameBtn;
    [SerializeField] private Button _settingBtn;
    [SerializeField] private Button _exitBtn;
    
    [SerializeField] private GameObject _settingUI;

    private void Start()
    {
        _continueBtn.onClick.AddListener(() => GameManager.Instance.ContinueMethod());
        _newGameBtn.onClick.AddListener(() => GameManager.Instance.GameStart());
        _settingBtn.onClick.AddListener(() =>
        {
            SettingManager.Instance.EnterSettingUI();
            _settingUI.SetActive(true);
        });
        _exitBtn.onClick.AddListener(() => GameManager.Instance.GameExit());
    }
}
