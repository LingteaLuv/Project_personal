using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class PlayerInteract : MonoBehaviour
{
    [Header("InputNumber")]
    [SerializeField] private float _interactDistance;

    private bool _isSensed;
    private void Awake()
    {
        Init();
    }

    public void Interact(bool isInteracted, bool isPressedEsc)
    {
        Vector3 origin = transform.position + Vector3.down * 0.5f;
        Vector3 direction = transform.forward;
        
        if (!_isSensed && isInteracted)
        {
            // Debug.DrawRay(origin, direction * _interactDistance, Color.red);
            
            if (Physics.Raycast(origin, direction, out RaycastHit hit ,_interactDistance))
            {
                Chest chest = hit.collider.GetComponentInParent<Chest>();
                TransferManager.Instance.OpenChest(chest);
                if(chest != null)
                {
                    _isSensed = true;
                }
            }
        }
        if (_isSensed && isPressedEsc)
        {
            TransferManager.Instance.CloseChest();
            _isSensed = false;
        }
    }
    
    private void Init()
    {
        
    }
}
