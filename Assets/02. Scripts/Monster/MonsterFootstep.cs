using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterFootstep : MonoBehaviour
{
    [Header("Drag&Drop")]
    [SerializeField] private AudioClip _footStep;
    
    private AudioSource _audioSource;
    private NavMeshAgent _agent;
    private bool _isPlayed;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        bool isMoved = _agent.velocity.magnitude > 0.1f;
        
        if (isMoved && !_isPlayed)
        {
            _audioSource.Play();
            _isPlayed = true;
        }

        if (!isMoved && _isPlayed)
        {
            _audioSource.Stop();
            _isPlayed = false;
        }
    }

    private void Init()
    {
        _agent = GetComponent<NavMeshAgent>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _footStep;
        _audioSource.loop = true;
        _audioSource.spatialBlend = 1;
        _audioSource.volume = 0.5f;

        _isPlayed = false;
    }
}
