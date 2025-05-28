using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerInputManager _playerInput;
    private PlayerAttack _playerAttack;
    private PlayerProperty _playerProperty;
    private PlayerStealth _playerStealth;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        _playerInput.InputUpdate();
        _playerMovement.RotateUpdate();
        _playerAttack.AtkUpdate(_playerInput.IsAttack, _playerProperty.CurWeapon);
        _playerProperty.ChangeWeapon(_playerInput.ChangeLeftWeapon, _playerInput.ChangeRightWeapon);
        _playerStealth.ChangePresence(_playerInput.IsHide);
    }

    private void FixedUpdate()
    {
        _playerMovement.MoveUpdate(_playerInput.InputDir, _playerInput.IsHide);
    }

    private void Init()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInput = GetComponent<PlayerInputManager>();
        _playerAttack = GetComponent<PlayerAttack>();
        _playerProperty = GetComponent<PlayerProperty>();
        _playerStealth = GetComponentInChildren<PlayerStealth>();
    }
}
