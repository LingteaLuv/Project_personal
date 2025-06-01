using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapReveal : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private Transform _player;
    [SerializeField] private ObjectGenerator _minimapObject;
    
    [Header("InputNumber")] 
    [SerializeField] private float _revealRange;
        
    private List<GameObject> _tiles;
    private List<GameObject> _stuffs;
    
    
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        Vector3 targetPos = new Vector3(_player.position.x / 5, -1, _player.position.z / 5);
        foreach (var tile in _tiles)
        {
            if (Vector3.Distance(tile.transform.position, targetPos) < _revealRange)
            {
                tile.SetActive(true);
            }
        }
        foreach (var stuff in _stuffs)
        {
            if (Vector3.Distance(stuff.transform.position, targetPos) < _revealRange)
            {
                stuff.SetActive(true);
            }
        }
    }

    private void Init()
    {
        _stuffs = StuffManager.Instance.StuffList;
        
        _tiles = new List<GameObject>();
        foreach (var tile in transform.Find("Tiles").GetComponentsInChildren<MeshFilter>())
        {
            tile.gameObject.SetActive(false);
            _tiles.Add(tile.gameObject);
        }
    }
}
