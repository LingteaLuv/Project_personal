using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameTag : MonoBehaviour
{
    [Header("Drag&Drop")]
    [SerializeField] private TMP_Text _name;

    private Camera _camera;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        _name.transform.LookAt(_camera.transform.position);
    }

    private void Init()
    {
        _camera = GetComponent<Canvas>().worldCamera;
    }
}
