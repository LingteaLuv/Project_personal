using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameClearUI : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private Image _background;
    [SerializeField] private TMP_Text _select;
    [SerializeField] private Button _backpack;
    [SerializeField] private Button _compass;
    [SerializeField] private Button _lantern;
    [SerializeField] private List<TMP_Text> _texts1;
    [SerializeField] private List<TMP_Text> _texts2;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        _backpack.onClick.AddListener(()=>
        {
            if (ItemManager.Instance.HasBackpack)
            {
                StartCoroutine(SelectItem());
                ItemManager.Instance.GetBackpack();
            }
        });
        _compass.onClick.AddListener(()=>
        {
            if (ItemManager.Instance.HasCompass)
            {
                StartCoroutine(SelectItem());
                ItemManager.Instance.GetCompass();
            }
        });
        _lantern.onClick.AddListener(()=>
        {
            if(ItemManager.Instance.HasLantern)
            {
                StartCoroutine(SelectItem());
                ItemManager.Instance.GetLantern();
            }
        });

        if (!ItemManager.Instance.HasBackpack && !ItemManager.Instance.HasCompass && !ItemManager.Instance.HasLantern)
        {
            StartCoroutine(HiddenText());
        }
    }

    private IEnumerator HiddenText()
    {
        _select.gameObject.SetActive(false);
        _backpack.gameObject.SetActive(false);
        _compass.gameObject.SetActive(false);
        _lantern.gameObject.SetActive(false);
        
        for (int i = 0; i < _texts2.Count; i++)
        {
            _texts2[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
        
        float timer = 0;
        float duration = 2f;

        Vector3 start = new Vector3(1, 1, 1);
        Vector3 end = new Vector3(4, 4, 1);

        while (timer < duration)
        {
            timer += Time.deltaTime;
            _background.transform.localScale = Vector3.Lerp(start, end, timer/duration);
            yield return null;
        }
        
        SceneManager.LoadScene("Title");
    }
    
    private IEnumerator SelectItem()
    {
        _select.gameObject.SetActive(false);
        _backpack.gameObject.SetActive(false);
        _compass.gameObject.SetActive(false);
        _lantern.gameObject.SetActive(false);
        
        for (int i = 0; i < _texts1.Count; i++)
        {
            _texts1[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }

        float timer = 0;
        float duration = 1.5f;

        Vector3 start = new Vector3(1, 1, 1);
        Vector3 end = new Vector3(2, 2, 1);

        while (timer < duration)
        {
            timer += Time.deltaTime;
            _background.transform.localScale = Vector3.Lerp(start, end, timer/duration);
            yield return null;
        }
        
        SceneManager.LoadScene("Title");
    }
    
    private void Init()
    {
        for (int i = 0; i < _texts1.Count; i++)
        {
            _texts1[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _texts2.Count; i++)
        {
            _texts2[i].gameObject.SetActive(false);
        }
    }
}
