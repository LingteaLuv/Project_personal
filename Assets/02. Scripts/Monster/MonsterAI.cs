using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private List<Transform> _patrolPoints;
    
    private Transform _curTarget;

    private void Awake()
    {
        Init();
    }
    
    private void Start()
    {
        SetCurTarget();
    }
    
    public void AIUpdate(bool first, bool second, Transform player)
    {
        if (first)
        {
            _agent.velocity = Vector3.zero;
            transform.LookAt(player.position);
        }

        else if (second)
        {
            transform.LookAt(player.position);
            _agent.SetDestination(player.position);
        }

        else
        {
            if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
            {
                SetCurTarget();
            }
        }
    }

    private void Init()
    {
        //_patrolPoints = new List<Transform>();
    }
    
    private void SetCurTarget()
    {
        if (_patrolPoints.Count == 0) return;

        int curIndex = Random.Range(0, _patrolPoints.Count);
        _curTarget = _patrolPoints[curIndex];
        _agent.SetDestination(_curTarget.position);
    }
}
