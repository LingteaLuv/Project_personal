using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private List<Stuff> _chest;
    private List<Stuff> _playerInventory;
    private int _volume;
    public int Volume => _volume;
    private GameObject _chestUI;
    public GameObject ChestUI => _chestUI;
    
    public int Count => _chest.Count;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        UIBinder.Instance.Mediate(this);
        _chestUI = UIBinder.Instance.GetChestUI().transform.GetChild(1).gameObject;
    }

    public Stuff FindObject(int index)
    {
        if (index >= Count) return null;
        return _chest[index];
    }
    
    public void AddStuff(Stuff stuff)
    {
        if (_chest.Count < _volume)
        {
            _chest.Add(stuff);
        }
        else
        {
            TextManager.Instance.PopupTextForSecond("popup_002", 3f);
        }
    }
    
    public void RemoveStuff(Stuff stuff, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            _chest.Remove(stuff);
        }
    }
    
    public bool HasStuff(Stuff stuff)
    {
        for (int i = 0; i < _chest.Count; i++)
        {
            if (_chest[i] == stuff)
            {
                return true;
            }
        }
        return false;
    }
    
    private void Init()
    {
        _chest = new List<Stuff>();
        _volume = 10;
    }
}
