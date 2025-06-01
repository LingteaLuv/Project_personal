using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootStep : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private AudioClip _footStep;
    
    private AudioSource _audioSource;

    private bool _isPlayed;

    private void Awake()
    {
        Init();
    }

    public void PlaySound(bool isMoved)
    {
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
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _footStep;
        _audioSource.loop = true;
        _audioSource.spatialBlend = 1;
    }
}
