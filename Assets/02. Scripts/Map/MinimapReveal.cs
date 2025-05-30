using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapReveal : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private Transform _player;

    [Header("InputNumber")] 
    [SerializeField] private float _revealRange;
        
    private List<GameObject> _tiles;
    
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        foreach (var tile in _tiles)
        {
            Vector3 targetPos = new Vector3(_player.position.x / 5, -1, _player.position.z / 5);
            if (Vector3.Distance(tile.transform.position, targetPos) < _revealRange)
            {
                tile.SetActive(true);
            }
        }
    }

    private void Init()
    {
        _tiles = new List<GameObject>();
        foreach (var tile in GetComponentsInChildren<MeshFilter>())
        {
            tile.gameObject.SetActive(false);
            _tiles.Add(tile.gameObject);
        }
    }
}
