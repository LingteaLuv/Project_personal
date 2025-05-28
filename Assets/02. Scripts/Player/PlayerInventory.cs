using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<Stuff> _stuffInventory;
    private void Awake()
    {
        Init();
    }

    public void AddStuff(Stuff stuff)
    {
        _stuffInventory.Add(stuff);
    }

    private void Init()
    {
        _stuffInventory = new List<Stuff>();
    }
}
