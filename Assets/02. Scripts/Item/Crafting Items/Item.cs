using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private GameObject _prefab;
    public GameObject Prefab => _prefab;
    [SerializeField] private string _description;
}
