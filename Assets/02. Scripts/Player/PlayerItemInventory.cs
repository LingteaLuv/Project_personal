using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerItemInventory : MonoBehaviour
{
    private List<Item> _items;
    private Dictionary<Item, GameObject> _spawnedItem;

    private bool _isBowAdded;
    private bool _isGrenadeAdded;
    
    private void Awake()
    {
        Init();
    }

    public void AddItem(Item item)
    {
        if (ConfigItem(item) < 1)
        {
            _items.Add(item);
            GameObject itemObject = Instantiate(item.Prefab, transform);
            _spawnedItem.Add(item, itemObject);

            if (item.name == "Bow")
            {
                transform.parent.GetComponentInChildren<Bow_T>().enabled = true;
                _isBowAdded = true;
            }

            if (item.name == "Grenade")
            {
                transform.parent.GetComponentInChildren<Grenade>().enabled = true;
                _isGrenadeAdded = true;
            }
        }
    }

    public bool GetIsBowAdded()
    {
        if (_isBowAdded)
        {
            _isBowAdded = false;
            return true;
        }
        return false;
    }

    public bool GetIsGrenadeAdded()
    {
        if (_isGrenadeAdded)
        {
            _isGrenadeAdded = false;
            return true;
        }
        return false;
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

    public void RemoveItem(Item item)
    {
        _items.Remove(item);
        if (_spawnedItem.TryGetValue(item, out GameObject itemObject))
        {
            Destroy(itemObject);
            _spawnedItem.Remove(item);
        }
    }
    
    private void Init()
    {
        _items = new List<Item>();
        _spawnedItem = new Dictionary<Item, GameObject>();
    }
}
