using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapObject : MonoBehaviour
{
    [Header("Drag&Drop")]
    [SerializeField] private ObjectGenerator _generator;
    [SerializeField] private GameObject _objectPrefab;

    private List<Vector3Int> _stuffPosList;
    private List<GameObject> _stuffList;
    public List<GameObject> StuffList => _stuffList;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        _stuffPosList = _generator.StuffPosList;
        GenerateObject();
    }

    private void GenerateObject()
    {
        foreach (var pos in _stuffPosList)
        {
            GameObject stuff = Instantiate(_objectPrefab, pos, Quaternion.identity, transform);
            stuff.SetActive(false);
            _stuffList.Add(stuff);
        }
    }

    private void Init()
    {
        _stuffPosList = new List<Vector3Int>();
        _stuffList = new List<GameObject>();
    }
}
