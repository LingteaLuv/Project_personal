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
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    private void LateUpdate()
    {
        transform.position = new Vector3(_player.position.x / 5, transform.position.y, _player.position.z / 5);
        if (!ItemManager.Instance.HasCompass)
        {
            transform.rotation = Quaternion.Euler(90,_player.rotation.eulerAngles.y,0);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.position += Vector3.up * (scroll * _zoomSpeed);

        float clampY = Mathf.Clamp(transform.position.y, _minY, _maxY);
        transform.position = new Vector3(transform.position.x, clampY, transform.position.z);
    }
}
