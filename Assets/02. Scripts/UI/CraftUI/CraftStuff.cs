using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CraftStuff : MonoBehaviour
{
    [Header("Drag&Drop")]
    [SerializeField] private List<Image> _craftInventoryList;
    [SerializeField] private List<Button> _craftInventoryBtnList;
    [SerializeField] private Sprite _basicSprite;

    private Crafting _craftNPC;
    
    private void Awake()
        {
            Init();
        }
    
        private void Start()
        {
            for (int i = 0; i < _craftInventoryBtnList.Count; i++)
            {
                int index = i;
                _craftInventoryBtnList[i].onClick.AddListener(() => OnCraftButtonClicked(index));
            }
        }
    
        private void OnCraftButtonClicked(int index)
        {
            Stuff stuff = _craftNPC.FindObject(index);
            TransferManager.Instance.TransferFromNPC(stuff);
        }
        
        private void Update()
        {
            if (UIManager.Instance.CurUI.Peek() == transform.parent.gameObject)
            {
                for (int i = 0; i < _craftNPC.CraftStuff.Count; i++)
                {
                    _craftInventoryList[i].sprite = _craftNPC.FindObject(i).Icon;
                }
    
                for (int i = _craftNPC.CraftStuff.Count; i < _craftInventoryList.Count; i++)
                {
                    _craftInventoryList[i].sprite = _basicSprite;
                }
            }
        }
        
        public void SetProperty(Crafting craftNPC)
        {
            _craftNPC = craftNPC;
        }
        
        private void Init()
        {
            _craftInventoryList = new List<Image>();
            _craftInventoryBtnList = new List<Button>();
            for (int i = 0; i < 2; i++)
            {
                Transform child = transform.GetChild(i);
                _craftInventoryList.Add(child.GetComponent<Image>());
                _craftInventoryBtnList.Add(child.GetComponent<Button>());
            }
        }
}
