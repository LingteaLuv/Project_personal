using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemInventory : MonoBehaviour
{
    [SerializeField] private List<Item> _items;

    public int Count => _items.Count;
    private void Awake()
    {
        Init();
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public int ConfigItem(Item item)
    {
        int amount = 0;
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i] == item)
            {
                amount++;
            }
        }
        return amount;
    }

    public void RemoveItem(Item item, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            _items.Remove(item);
        }
    }
    
    private void Init()
    {
        _items = new List<Item>();
    }
}
