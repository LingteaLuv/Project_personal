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

    private bool _isChestOpened;
    private bool _isPortalInteracted;
    
    private void Awake()
    {
        Init();
    }

    public void Interact(bool isInteracted, bool isPressedEsc)
    {
        Vector3 origin = transform.position + Vector3.down * 0.5f;
        Vector3 direction = transform.forward;
        
        if (!_isChestOpened && isInteracted)
        {
            if (Physics.Raycast(origin, direction, out RaycastHit hit ,_interactDistance))
            {
                if (hit.collider.gameObject.layer == 15)
                {
                    Chest chest = hit.collider.GetComponentInParent<Chest>();
                    if(chest != null)
                    {
                        TransferManager.Instance.OpenChest(chest);
                        _isChestOpened = true;
                    }
                }
                else if (hit.collider.gameObject.layer == 14)
                {
                    Portal portal = hit.collider.GetComponentInParent<Portal>();
                    if (portal != null)
                    {
                        portal.InteractPortal();
                        _isPortalInteracted = true;
                    }
                }
            }
        }
        if (_isChestOpened && isPressedEsc)
        {
            TransferManager.Instance.CloseChest();
            _isChestOpened = false;
        }

        if (_isPortalInteracted && isPressedEsc)
        {
            UIManager.Instance.CloseUI();
        }
    }
    
    private void Init()
    {
        
    }
}
