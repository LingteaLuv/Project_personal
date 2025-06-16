using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootStep : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private AudioClip _footStep;
    
    public AudioSource _audioSource;

    private bool _isPlayed;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        GameManager.Instance.IsPaused.OnChanged -= GamePause;
        GameManager.Instance.IsPaused.OnChanged += GamePause;
    }
    
    private void OnDestroy()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.IsPaused.OnChanged -= GamePause;
    }
    
    private void GamePause(bool isPaused)
    {
        if (isPaused)
        {
            _audioSource.Pause();
        }
        else
        {
            _audioSource.UnPause();
        }
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
        _audioSource.pitch = 0.7f;
    }
}
