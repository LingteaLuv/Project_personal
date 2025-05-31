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
    [SerializeField] private int _offset;
    public int Offset => _offset;

    private int _safeZoneStart;
    public int SafeZoneStart => _safeZoneStart;
    private int _safeZoneEnd;
    public int SafeZoneEnd => _safeZoneEnd;
    
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
        _map = new int[_offset * _mapSize, _offset * _mapSize];
        
        // 벽 데이터
        for (int x = 0; x < _mapSize; x++)
        {
            for (int y = 0; y < _mapSize; y++)
            {
                _map[_offset * x, _offset * y] = 1;
            }
        }

        // 안전 구역 데이터
        for (int x = _safeZoneStart; x < _safeZoneEnd; x++)
        {
            for (int y = _safeZoneStart; y < _safeZoneEnd; y++)
            {
                _map[_offset * x, _offset * y] = 2;
            }
        }

        _map[_offset, _offset] = 0;
        GenerateMaze(_offset,_offset);

        _map[_offset * (_safeZoneStart - 1), _offset * (_mapSize / 2)] = 0;
        _map[_offset * _safeZoneEnd, _offset * (_mapSize / 2)] = 0;
        _map[_offset * (_mapSize / 2), _offset * (_safeZoneStart - 1)] = 0;
        _map[_offset * (_mapSize / 2), _offset * _safeZoneEnd] = 0;
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
            int nextX = x + direction.x * 2 * _offset;
            int nextY = y + direction.y * 2 * _offset;

            if (nextX < 0 || nextX >= (_mapSize - 1) * _offset || nextY < 0 || nextY >= (_mapSize - 1) * _offset)
            {
                continue;
            }
            
            if (nextX <= _safeZoneEnd * _offset && nextX >= _safeZoneStart * _offset && nextY <= _safeZoneEnd * _offset && nextY >= _safeZoneStart * _offset)
            {
                continue;
            }

            if (_map[nextX, nextY] == 1)
            {
                _map[nextX, nextY] = 0;
                _map[ x + _offset * direction.x, y + _offset * direction.y] = 0;
                GenerateMaze(nextX, nextY);
            }
        }
    }
}
