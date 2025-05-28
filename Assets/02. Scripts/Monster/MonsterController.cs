using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private MonsterDetect _monsterDetect;
    private MonsterAI _monsterAI;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        _monsterDetect.Detect();
        _monsterAI.AIUpdate(_monsterDetect.IsFirstDetect, _monsterDetect.IsSecondDetect, _monsterDetect.Target);
    }

    private void Init()
    {
        _monsterDetect = GetComponentInChildren<MonsterDetect>();
        _monsterAI = GetComponent<MonsterAI>();
    }
}
