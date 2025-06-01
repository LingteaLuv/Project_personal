using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private KeyCode _atkKey;

    private bool _isAttack;
    public bool IsAttack => _isAttack;
    private Vector3 _inputDir;
    public Vector3 InputDir => _inputDir;

    private bool _changeRightWeapon;
    public bool ChangeRightWeapon => _changeRightWeapon;
    private bool _changeLeftWeapon;
    public bool ChangeLeftWeapon => _changeLeftWeapon;

    private bool _isHide;
    public bool IsHide => _isHide;

    private bool _isPickUp;
    public bool IsPickUp => _isPickUp;

    private bool _isInteracted;
    public bool IsInteracted => _isInteracted;
    
    private bool _isPressEsc;
    public bool IsPressEsc => _isPressEsc;

    private bool _isMoved;
    public bool IsMoved => _isMoved;
    
    private void Awake()
    {
        Init();
    }

    /// <summary>
    /// 플레이어 입력을 감지하고 프로퍼티를 변경하는 메서드
    /// </summary>
    public void InputUpdate()
    {
        MoveInput();

        _isAttack = Input.GetKeyDown(_atkKey);
        _changeLeftWeapon = Input.GetKeyDown(KeyCode.Q);
        _changeRightWeapon = Input.GetKeyDown(KeyCode.E);
        _isPickUp = Input.GetKeyDown(KeyCode.R);
        _isHide = Input.GetKey(KeyCode.LeftShift);
        _isInteracted = Input.GetKeyDown(KeyCode.F);
        _isPressEsc = Input.GetKeyDown(KeyCode.Escape);
    }

    private void MoveInput()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        _inputDir = new Vector3(x, 0, z).normalized;

        if (_inputDir.magnitude > 0.1f)
        {
            _isMoved = true;
        }
        else
        {
            _isMoved = false;
        }
    }
    
    private void Init()
    {
        
    }
}
