using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private Stuff _fibber;
    [SerializeField] private Stuff _rubber;
    [SerializeField] private Stuff _stone;
    [SerializeField] private Stuff _wood;
    [SerializeField] private GameObject _monsterPrefab;
    [SerializeField] private GameObject _escapePortalPrefab;
    [SerializeField] private MapData _mapData;

    [Header("InputNumber")] 
    [SerializeField][Range(1,10)] private int _fibberAmount;
    [SerializeField][Range(1,10)] private int _rubberAmount;
    [SerializeField][Range(1,10)] private int _stoneAmount;
    [SerializeField][Range(1,10)] private int _woodAmount;
    [SerializeField][Range(1,10)] private int _monsterAmount;

    private int _offset;
    private Vector3Int _escapePortalPos;

    private List<Vector3Int> _stuffPosList;
    public List<Vector3Int> StuffPosList => _stuffPosList;
    
    private void Awake()
    {
        _offset = _mapData.Offset;
        _stuffPosList = new List<Vector3Int>();
    }
    
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        Generate(_fibber.Prefab, _fibberAmount);
        Generate(_rubber.Prefab, _rubberAmount);
        Generate(_stone.Prefab, _stoneAmount);
        Generate(_wood.Prefab, _woodAmount);
        GenerateMonster(_monsterPrefab, _monsterAmount);
        GenerateEscapePortal(_escapePortalPrefab);
    }
    
    private Vector3Int GetRndPosition()
    {
        Vector3Int result = new Vector3Int();
        while (result == Vector3Int.zero)
        {
            int z1 = Random.Range(0, _mapData.SafeZoneStart);
            int z2 = Random.Range(_mapData.SafeZoneEnd, _mapData.MapSize);
            int z = Random.Range(0, 2) < 1 ? z1 : z2;
            int x1 = Random.Range(0, _mapData.SafeZoneStart);
            int x2 = Random.Range(_mapData.SafeZoneEnd, _mapData.MapSize);
            int x = Random.Range(0, 2) < 1 ? x1 : x2;
        
            if (_mapData.Map[z * _offset, x * _offset] == 0)
            {
                result = new Vector3Int(x * _offset, 0, z * _offset);
            }
        }
        return result;
    }

    private void Generate(GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3Int genPos = GetRndPosition();
            Instantiate(prefab, genPos, Quaternion.identity, transform);
            
            Vector3Int minimapGenPos = new Vector3Int(genPos.x / _offset, 0, genPos.z / _offset);
            _stuffPosList.Add(minimapGenPos);
        }
    }

    private void GenerateMonster(GameObject monsterprefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3Int genPos = GetRndPosition();
            GameObject monster = Instantiate(monsterprefab, genPos, Quaternion.identity, transform);
            monster.GetComponent<MonsterAI>().SetPatrolPoint(GetPatrolPos());
        }
    }

    private void GenerateEscapePortal(GameObject escapePortalPrefab)
    {
        Vector3Int result = new Vector3Int();
        Vector3 rotation = new Vector3();
        while (result == Vector3Int.zero)
        {
            Vector3 temprotation = new Vector3(0, 0, 0);
            int n = Random.Range(0, 2);
            int x = 0;
            int z = 0;
            if (n == 0)
            {
                z = Random.Range(1, _mapData.MapSize - 1);
                int x1 = 1;
                int x2 = _mapData.MapSize - 2;
                x = Random.Range(0, 2) < 1 ? x1 : x2;
            }
            else
            {
                x = Random.Range(1, _mapData.MapSize - 1);
                int z1 = 1;
                int z2 = _mapData.MapSize - 2;
                z = Random.Range(0, 2) < 1 ? z1 : z2;
                temprotation = new Vector3(0, 90, 0);
            }

            if (_mapData.Map[z * _offset, x * _offset] == 0)
            {
                result = new Vector3Int(x * _offset, 3, z * _offset);
                rotation = temprotation;
            }
        }

        Vector3Int genPos = result;
        GameObject monster = Instantiate(escapePortalPrefab, genPos, Quaternion.Euler(rotation), transform);
        _escapePortalPos = result;
    }
    

    private Vector3Int[] GetPatrolPos()
    {
        Vector3Int[] temp = new Vector3Int[5];
        int count = 0;
        while (count < 5)
        {
            int z1 = Random.Range(0, _mapData.SafeZoneStart);
            int z2 = Random.Range(_mapData.SafeZoneEnd, _mapData.MapSize);
            int z = Random.Range(0, 2) < 1 ? z1 : z2;
            int x1 = Random.Range(0, _mapData.SafeZoneStart);
            int x2 = Random.Range(_mapData.SafeZoneEnd, _mapData.MapSize);
            int x = Random.Range(0, 2) < 1 ? x1 : x2;
        
            if (_mapData.Map[z * _offset, x * _offset] == 0)
            {
                temp[count] = new Vector3Int(x * _offset, 0, z * _offset);
                count++;
            }
        }
        return temp;
    }
}
