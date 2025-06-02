using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftManager : Singleton<CraftManager>
{
    private Item _curCraftItem;
    
    public void SetCraftItem(Item item)
    {
        _curCraftItem = item;
    }

    public Item GetCraftItem()
    {
        Item result = _curCraftItem;
        _curCraftItem = null;
        return result;
    }
}
