using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private MonsterDetect _monsterDetect;
    private MonsterAI _monsterAI;
    private MonsterHit _monsterHit;
    private MonsterLoot _monsterLoot;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        _monsterDetect.Detect();
        _monsterAI.AIUpdate(_monsterDetect.IsFirstDetect, _monsterDetect.IsSecondDetect, _monsterDetect.Target);
        if (_monsterHit.IsDead)
        {
            _monsterLoot.Generate();
            Destroy(gameObject);
            GameManager.Instance.KillMonster();
        }
    }

    private void Init()
    {
        _monsterDetect = GetComponentInChildren<MonsterDetect>();
        _monsterAI = GetComponent<MonsterAI>();
        _monsterHit = GetComponentInChildren<MonsterHit>();
        _monsterLoot = GetComponent<MonsterLoot>();
    }
}
