using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Drag&Drop")]
    
    private PlayerMovement _playerMovement;
    private PlayerInputManager _playerInput;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        _playerInput.InputUpdate();
    }

    private void FixedUpdate()
    {
        _playerMovement.MoveUpdate(_playerInput.InputDir);
    }

    private void Init()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInput = GetComponent<PlayerInputManager>();
    }
}
