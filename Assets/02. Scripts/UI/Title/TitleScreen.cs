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
    [SerializeField] private Button _infoBtn;

    [SerializeField] private GameObject _settingUI;
    [SerializeField] private GameObject _infoUI;
    
    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        _startBtn.onClick.AddListener(() => SceneManager.LoadScene("InGame", LoadSceneMode.Single));
        _startBtn.onClick.AddListener(() => SceneManager.LoadScene("UI", LoadSceneMode.Additive));
        _settingBtn.onClick.AddListener(() => _settingUI.SetActive(true));
        _exitBtn.onClick.AddListener(() => Application.Quit());
        _infoBtn.onClick.AddListener(() => _infoUI.SetActive(true));
    }

    private void Init()
    {
        
    }
}
