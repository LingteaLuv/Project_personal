using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private List<Vector3Int> _patrolPoints;
    
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
    
    private void SetCurTarget()
    {
        if (_patrolPoints.Count == 0) return;

        int curIndex = Random.Range(0, _patrolPoints.Count);
        _agent.SetDestination(_patrolPoints[curIndex]);
    }

    public void SetPatrolPoint(Vector3Int[] points)
    {
        for (int i = 0; i < points.Length; i++)
        {
            _patrolPoints.Add(points[i]);
        }
    }
}
