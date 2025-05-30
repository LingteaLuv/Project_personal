using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapGenerator : MonoBehaviour
{
    [Header("Drag&Drop")]
    [SerializeField] private MinimapData _data;
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private GameObject _tilePrefab;
    
    private int[,] _map;
    private int _mapSize;

    private void Start()
    {
        Init();
        GenerateMap();
    }

    private void GenerateMap()
    {
        Debug.Log("생성");
        for (int z = 0; z < _mapSize; z++)
        {
            for (int x = 0; x < _mapSize; x++)
            {
                Vector3 pos = new Vector3(x, -1, z);
                if (_map[z, x] == 1)
                {
                    Instantiate(_wallPrefab, pos, Quaternion.identity,transform);
                }
                else
                {
                    Instantiate(_tilePrefab, pos, Quaternion.identity,transform);
                }
            }
        }
    }

    private void Init()
    {
        _map = _data.Map;
        _mapSize = _data.MapSize;
    }
}
