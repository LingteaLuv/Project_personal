using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private List<Stuff> _chest;
    private List<Stuff> _playerInventory;
    private int _volume;

    private void Awake()
    {
        Init();
    }

    public void AddStuff(Stuff stuff)
    {
        if (_chest.Count < _volume)
        {
            _chest.Add(stuff);
        }
        else
        {
            Debug.Log("상자가 가득 찼습니다.");
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
    }
}
