using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Drag&Drop")]
    [SerializeField] private MapData _data;
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private GameObject _safeZonePrefab;
    
    private int[,] _map;
    private int _mapSize;
    private int _offset;

    private BoxCollider _lightArea;

    private void Start()
    {
        Init();
        GenerateMap();
        SetLightArea();
    }

    private void GenerateMap()
    {
        for (int z = 0; z < _mapSize; z++)
        {
            for (int x = 0; x < _mapSize; x++)
            {
                Vector3 pos = new Vector3(_offset * x, 0, _offset * z);
                if (_map[_offset * z, _offset * x] == 1)
                {
                    Instantiate(_wallPrefab, pos, Quaternion.identity,transform);
                }
                else if(_map[_offset * z, _offset * x] == 0)
                {
                    Instantiate(_tilePrefab, pos, Quaternion.identity,transform);
                }
                else
                {
                    Instantiate(_safeZonePrefab, pos - Vector3.down * 0.01f, Quaternion.identity,transform);
                }
            }
        }
    }

    private void SetLightArea()
    {
        _lightArea.size = new Vector3(_mapSize - 1, 3f, _mapSize - 1);
        _lightArea.center = new Vector3((_mapSize - 1) * _offset / 2, 1.5f, (_mapSize - 1) * _offset / 2);
        _lightArea.isTrigger = true;
    }

    private void Init()
    {
        _map = _data.Map;
        _mapSize = _data.MapSize;
        _offset = _data.Offset;

        _lightArea = GetComponentInChildren<BoxCollider>();
    }
}
