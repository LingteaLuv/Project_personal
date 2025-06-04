using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStuff", menuName = "Stuff/StuffData")]
public class Stuff : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private GameObject _prefab;
    public GameObject Prefab => _prefab;
    [SerializeField] private Sprite _icon;
    public Sprite Icon => _icon;
    [SerializeField] private GameObject _minimapPrefab;
    public GameObject MinimapPrefab => _minimapPrefab;
}
