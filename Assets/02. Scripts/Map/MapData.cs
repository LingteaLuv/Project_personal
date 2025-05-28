using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapData : MonoBehaviour
{
    [Header("InputNumber")] 
    [SerializeField] private int _mapSize;
    public int MapSize => _mapSize;
    [SerializeField] private int _safeZoneSize;

    private int _safeZoneStart;
    private int _safeZoneEnd;
    
    private int[,] _map;
    public int[,] Map => _map;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _safeZoneStart = (_mapSize - _safeZoneSize) / 2 + 1;
        _safeZoneEnd = (_mapSize + _safeZoneSize) / 2 - 1;
        
        // 맵 데이터
        _map = new int[_mapSize, _mapSize];
        
        // 벽 데이터
        for (int x = 0; x < _mapSize; x++)
        {
            for (int y = 0; y < _mapSize; y++)
            {
                _map[x, y] = 1;
            }
        }

        // 안전 구역 데이터
        for (int x = _safeZoneStart; x < _safeZoneEnd; x++)
        {
            for (int y = _safeZoneStart; y < _safeZoneEnd; y++)
            {
                _map[x, y] = 0;
            }
        }

        _map[1, 1] = 0;
        GenerateMaze(1,1);

        _map[30, 37] = 0;
        _map[44, 37] = 0;
        _map[37, 30] = 0;
        _map[37, 44] = 0;
    }

    private void GetRndDirection(List<Vector2Int> dirList)
    {
        for (int i = 0; i < dirList.Count; i++)
        {
            Vector2Int tempDir = dirList[i];
            int rndIndex = Random.Range(i, dirList.Count);
            dirList[i] = dirList[rndIndex];
            dirList[rndIndex] = tempDir;
        }
    }

    private void GenerateMaze(int x, int y)
    {
        List<Vector2Int> directions = new List<Vector2Int>
        {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.right,
            Vector2Int.left,
        };
        GetRndDirection(directions);

        foreach (Vector2Int direction in directions)
        {
            int nextX = x + direction.x * 2;
            int nextY = y + direction.y * 2;

            if (nextX < 0 || nextX >= _mapSize - 1 || nextY < 0 || nextY >= _mapSize - 1)
            {
                continue;
            }
            
            if (nextX <= _safeZoneEnd && nextX >= _safeZoneStart && nextY <= _safeZoneEnd && nextY >= _safeZoneStart)
            {
                continue;
            }

            if (_map[nextX, nextY] == 1)
            {
                _map[nextX, nextY] = 0;
                _map[x + direction.x, y + direction.y] = 0;
                GenerateMaze(nextX, nextY);
            }
        }
    }
}
