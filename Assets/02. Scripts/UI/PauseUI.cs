using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private Button _continueBtn;
    [SerializeField] private Button _newGameBtn;
    [SerializeField] private Button _settingBtn;
    [SerializeField] private Button _exitBtn;
    
    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        _continueBtn.onClick.AddListener(() => GameManager.Instance.ContinueMethod());
        _newGameBtn.onClick.AddListener(() => SceneManager.LoadScene("InGame", LoadSceneMode.Single));
        _newGameBtn.onClick.AddListener(() => SceneManager.LoadScene("UI", LoadSceneMode.Additive));
        _settingBtn.onClick.AddListener(() => SettingManager.Instance.EnterSettingUI());
        _exitBtn.onClick.AddListener(() => SceneManager.LoadScene("Title", LoadSceneMode.Single));
    }

    private void Update()
    {
        
    }

    private void Init()
    {
        
    }
}
