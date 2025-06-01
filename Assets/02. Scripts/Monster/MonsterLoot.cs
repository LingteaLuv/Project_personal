using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLoot : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private List<Stuff> _drops;

    private float _rndNum;
    private Stuff _drop;
    private Stuff _luckyDrop;

    private void Awake()
    {
        Init();
    }

    public void Generate()
    {
        if (_drop != null)
        {
            GameObject drop = Instantiate(_drop.Prefab);
            drop.transform.position = transform.position + Vector3.down * 1f;
        }
       
        if (_luckyDrop != null)
        {
            GameObject luckyDrop = Instantiate(_luckyDrop.Prefab);
            luckyDrop.transform.position = transform.position + Vector3.down * 1f + Vector3.forward * 1f + Vector3.right * 1f;
        }
        
    }

    private void Init()
    {
        _rndNum = Random.Range(0, 10);
        if (_rndNum < 5)
        {
            _drop = _drops[0];
        }
        else if (_rndNum < 9)
        {
            _drop = _drops[1];
        }
        else
        {
            _drop = _drops[0];
            _luckyDrop = _drops[1];
        }
    }
}
