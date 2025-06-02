using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerInputManager _playerInput;
    private PlayerAttack _playerAttack;
    private PlayerWeapon _playerWeapon;
    private PlayerStealth _playerStealth;
    private PlayerPickUp _playerPickUp;
    private PlayerInventory _inventory;
    private PlayerInteract _playerInteract;
    private PlayerCam _playerCam;
    private PlayerFootStep _playerFootStep;
    private PlayerProperty _playerProperty;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        
    }
    
    private void Update()
    {
        _playerInput.InputUpdate();
        _playerProperty.HideUpdate(_playerInput.IsHide);
        _playerMovement.RotateUpdate();
        _playerFootStep.PlaySound(_playerInput.IsMoved);
        _playerAttack.AtkUpdate(_playerInput.IsAttack, _playerWeapon.CurWeapon);
        _playerWeapon.ChangeWeapon(_playerInput.ChangeLeftWeapon, _playerInput.ChangeRightWeapon);
        _playerCam.ChangePos(_playerInput.IsHide);
        _playerPickUp.ConfigItem();
        _playerInteract.Interact(_playerInput.IsInteracted, _playerInput.IsPressEsc);
        
        if (_playerInput.IsPickUp && _playerPickUp.CanPickUp)
        {
            _playerPickUp.PickUp(_inventory);
        }
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
        _playerWeapon = GetComponent<PlayerWeapon>();
        _playerStealth = GetComponentInChildren<PlayerStealth>();
        _playerCam = GetComponentInChildren<PlayerCam>();
        _playerPickUp = GetComponentInChildren<PlayerPickUp>();
        _inventory = GetComponent<PlayerInventory>();
        _playerInteract = GetComponent<PlayerInteract>();
        _playerFootStep = GetComponent<PlayerFootStep>();
        _playerProperty = GetComponent<PlayerProperty>();
        
        _playerMovement.GetProperty(_playerProperty);
        _playerStealth.GetProperty(_playerProperty);
    }
}
