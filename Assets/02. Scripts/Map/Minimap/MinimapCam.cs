using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class MinimapCam : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private Transform _player;

    [Header("InputNumber")] 
    [SerializeField] private float _zoomSpeed;
    [SerializeField] private float _minZoom;
    [SerializeField] private float _maxZoom;

    private Camera _minimapCam;

    private void Awake()
    {
        Init();
    }
    
    private void LateUpdate()
    {
        transform.position = new Vector3(_player.position.x / 5, transform.position.y, _player.position.z / 5);
        if (ItemManager.Instance.HasCompass)
        {
            transform.rotation = Quaternion.Euler(90,_player.rotation.eulerAngles.y,0);
        }

        
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        _minimapCam.orthographicSize += scroll * -_zoomSpeed;

        _minimapCam.orthographicSize = Mathf.Clamp(_minimapCam.orthographicSize, _minZoom, _maxZoom);
    }

    private void Init()
    {
        _minimapCam = GetComponent<Camera>();
        _minimapCam.orthographicSize = 10;
    }
}
