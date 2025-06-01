using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [Header("Drag&Drop")]
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _playerPrefab;

    [Header("InputNumber")] 
    [SerializeField][Range(0,1)] private float _posX;
    [SerializeField][Range(0,1)] private float _posY;
    [SerializeField] [Range(0, 1)] private float _size;
    
    private GameObject _playerObject;
    private bool _isTurnOn;
    private Camera _minicam;
    
    
    
    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        Vector3 startPos = new Vector3(_player.position.x / 5, -1, _player.position.z / 5);
        _playerObject = Instantiate(_playerPrefab, startPos, Quaternion.identity);
    }
    
    private void Update()
    {
        _playerObject.transform.position = new Vector3(_player.position.x / 5, -1, _player.position.z / 5);
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _isTurnOn = !_isTurnOn;
            if (_isTurnOn != _minicam.gameObject.activeSelf)
            {
                _minicam.gameObject.SetActive(_isTurnOn);
            }
        }
    }

    private void Init()
    {
        _minicam = GetComponentInChildren<Camera>();
        _minicam.rect = new Rect(_posX + _size * 7 / 16, _posY, _size * 9 / 16, _size);
        _isTurnOn = false;
        _minicam.gameObject.SetActive(_isTurnOn);
    }
}
