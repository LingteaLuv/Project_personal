using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    private MonsterDetect _monsterDetect;
    private MonsterAI _monsterAI;
    private MonsterHit _monsterHit;
    private MonsterLoot _monsterLoot;
    private MonsterFootstep _monsterFootstep;
    private MonsterAnimator _animator;

    private NavMeshAgent _agent;
    private bool _isMoved;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        _monsterDetect.Detect();
        _monsterAI.AIUpdate(_monsterDetect.IsFirstDetect, _monsterDetect.IsSecondDetect, _monsterDetect.Target);
        _isMoved = _agent.velocity.magnitude > 0.1f;
        _monsterFootstep.FootstepUpdate(_isMoved);
        _animator.AnimationUpdate(_isMoved);
        
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
        _monsterFootstep = GetComponent<MonsterFootstep>();
        _animator = GetComponent<MonsterAnimator>();

        _agent = GetComponent<NavMeshAgent>();
    }
}
