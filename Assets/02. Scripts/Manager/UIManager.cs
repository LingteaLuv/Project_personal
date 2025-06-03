using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UIManager : Singleton<UIManager>
{
    [Header("Drag&Drop")] 
    [SerializeField] private PauseUI _pauseUI;
    [SerializeField] private StatusUI _statusUI;
    [SerializeField] private InventoryUI _inventoryUI;
    [SerializeField] private InventoryInChestUI _inventoryInChestUI;
    [SerializeField] private ChestInventoryUI _chestInventoryUI;
    [SerializeField] private ChestUI _chestUI;
    [SerializeField] private CraftStuff _craftStuff;
    [SerializeField] private PopUpUI _popUpUI;
    [SerializeField] private InventoryInCraftUI _inventoryInCraftUI;
    [SerializeField] private CraftResult _craftResult;
    public PopUpUI PopUpUI => _popUpUI;

    private TextLoader _textLoader;
    public GameObject CurUI;

    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    public void PopupText(string id)
    {
        string popupText = _textLoader.GetPopupText(id);
        _popUpUI.gameObject.SetActive(true);
        _popUpUI.PopupText(popupText);
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
        _popUpUI.gameObject.SetActive(false);
    }
    
    public ChestUI GetChestUI()
    {
        return _chestUI;
    }

    public CraftStuff GetCraftUI()
    {
        return _craftStuff;
    }
    
    public void OpenUI(GameObject curUI)
    {
        if (curUI != null)
        {
            CurUI = curUI;
            CurUI.gameObject.SetActive(true);
        }
    }

    public void CloseUI()
    {
        CurUI.gameObject.SetActive(false);
        CurUI = null;
    }

    public void GamePause()
    {
        CurUI = _pauseUI.gameObject;
        CurUI.SetActive(true);
    }

    public void Mediate(PlayerProperty playerProperty)
    {
        _statusUI.SetProperty(playerProperty);
    }

    public void Mediate(PlayerInventory playerInventory)
    {
        _inventoryUI.SetProperty(playerInventory);
        _inventoryInChestUI.SetProperty(playerInventory);
        _inventoryInCraftUI.SetProperty(playerInventory);
    }

    public void Mediate(Chest chest)
    {
        _chestInventoryUI.SetProperty(chest);
    }

    public void Mediate(Crafting craftNPC)
    {
        _craftStuff.SetProperty(craftNPC);
        _craftResult.SetProperty(craftNPC);
    }
    
    private void Init()
    {

    }
}
