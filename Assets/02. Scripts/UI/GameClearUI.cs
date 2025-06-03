using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClearUI : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private TMP_Text _select;
    [SerializeField] private Button _backpack;
    [SerializeField] private Button _compass;
    [SerializeField] private Button _lantern;
    [SerializeField] private List<TMP_Text> _texts;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        _backpack.onClick.AddListener(()=>
        {
            ItemManager.Instance.GetBackpack();
            StartCoroutine(SelectItem());
        });
        _compass.onClick.AddListener(()=>
        {
            ItemManager.Instance.GetCompass();
            StartCoroutine(SelectItem());
        });
        _lantern.onClick.AddListener(()=>
        {
            ItemManager.Instance.GetLantern();
            StartCoroutine(SelectItem());
        });
    }

    private IEnumerator SelectItem()
    {
        _select.gameObject.SetActive(false);
        _backpack.gameObject.SetActive(false);
        _compass.gameObject.SetActive(false);
        _lantern.gameObject.SetActive(false);
        
        for (int i = 0; i < _texts.Count; i++)
        {
            _texts[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(2f);
        
        SceneManager.LoadScene("Title");
    }
    
    private void Init()
    {
        for (int i = 0; i < _texts.Count; i++)
        {
            _texts[i].gameObject.SetActive(false);
        }
    }
}
