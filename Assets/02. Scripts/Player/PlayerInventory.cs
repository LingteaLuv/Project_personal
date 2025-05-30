using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<Stuff> _stuffInventory;
    [SerializeField] private int _maxCount;
    
    public int Count => _stuffInventory.Count;
    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        if (ItemManager.Instance.HasBackpack)
        {
            _maxCount = 5;
        }
    }

    public void AddStuff(Stuff stuff)
    {
        if (_stuffInventory.Count < _maxCount)
        {
            _stuffInventory.Add(stuff);
        }
        else
        {
            Debug.Log("인벤토리가 가득 찼습니다.");
        }
    }

    public bool HasStuff(Stuff stuff)
    {
        for (int i = 0; i < _stuffInventory.Count; i++)
        {
            if (_stuffInventory[i] == stuff)
            {
                return true;
            }
        }
        return false;
    }
    
    public int ConfigStuff(Stuff stuff)
    {
        int amount = 0;
        for (int i = 0; i < _stuffInventory.Count; i++)
        {
            if (_stuffInventory[i] == stuff)
            {
                amount++;
            }
        }
        return amount;
    }

    public void RemoveStuff(Stuff stuff, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            _stuffInventory.Remove(stuff);
        }
    }
    
    private void Init()
    {
        _stuffInventory = new List<Stuff>();
        _maxCount = 2;
    }
}
