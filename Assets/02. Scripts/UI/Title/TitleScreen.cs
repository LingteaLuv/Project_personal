using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private Button _startBtn;
    [SerializeField] private Button _settingBtn;
    [SerializeField] private Button _exitBtn;

    [SerializeField] private GameObject _settingUI;
    
    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        _startBtn.onClick.AddListener(() => SceneManager.LoadScene("InGame", LoadSceneMode.Single));
        _startBtn.onClick.AddListener(() => SceneManager.LoadScene("UI", LoadSceneMode.Additive));
        _settingBtn.onClick.AddListener(() =>
        {
            SettingManager.Instance.EnterSettingUI();
            _settingUI.SetActive(true);
        });
        _exitBtn.onClick.AddListener(() => 
        {
            Application.Quit();
            Debug.Log("게임 종료");
        });
    }

    private void Init()
    {
        
    }
}
