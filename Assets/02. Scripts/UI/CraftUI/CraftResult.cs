using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftResult : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private Image _resultImage;
    [SerializeField] private Button _resultBtn;
    [SerializeField] private Sprite _basicSprite;

    private Crafting _craftNPC;
    private Recipe _resultRecipe;
    
    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        _resultBtn.onClick.AddListener(()=>OnResultBtnClicked());
    }
    
    private void Update()
    {
        _resultRecipe = _craftNPC.CanCraft();
        if (_resultRecipe != null)
        {
            _resultImage.sprite = _resultRecipe.Icon;
        }
        else
        {
            _resultImage.sprite = _basicSprite;
        }
    }

    private void OnResultBtnClicked()
    {
        if (_resultRecipe != null)
        {
            ItemManager.Instance.GetItem(_craftNPC.Craft(_resultRecipe));
        }
    }
    
    public void SetProperty(Crafting craftNPC)
    {
        _craftNPC = craftNPC;
    }
    
    private void Init()
    {
        
    }
}
