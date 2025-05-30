using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MinimapData : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private MapData _mapData;
    
    private int _mapSize;
    public int MapSize => _mapSize;
    
    private int[,] _map;
    public int[,] Map => _map;

    private int _offset;

    private void Start()
    {
        Init();
        Initialize();
    }

    private void Initialize()
    {
        // 미니맵 생성
        _map = new int[_mapSize, _mapSize];
        
        // 맵 크기 보정
        for (int x = 0; x < _mapSize; x++)
        {
            for (int y = 0; y < _mapSize; y++)
            {
                _map[x, y] = _mapData.Map[x * _offset, y * _offset];
            }
        }
    }

    private void Init()
    {
        _mapSize = _mapData.MapSize;
        _offset = _mapData.Offset;
    }
}
