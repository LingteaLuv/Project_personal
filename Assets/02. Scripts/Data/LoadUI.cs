using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadUI : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private List<Button> _slots;
    [SerializeField] private List<TMP_Text> _texts;
    [SerializeField] private Button _exitBtn;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            int slotIndex = i;
            _slots[slotIndex].onClick.AddListener(()=>
            {
                if (DataManager.Instance.LoadData(slotIndex))
                {
                    GameManager.Instance.GameStart();
                }
            });
        }
        SetText();
        DataManager.Instance.OnFileChanged += SetText;
        
        _exitBtn.onClick.AddListener(()=> gameObject.SetActive(false));
    }
    
    private void SetText()
    {
        for (int i = 0; i < _texts.Count; i++)
        {
            int slotIndex = i;
            _texts[i].text = DataManager.Instance.ExistData(slotIndex) ? "File Exist" : "Empty";
        }
    }
}
