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
    }

    private void MoveInput()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        _inputDir = new Vector3(x, 0, z).normalized;
    }
    
    
    private void Init()
    {
        
    }
}
