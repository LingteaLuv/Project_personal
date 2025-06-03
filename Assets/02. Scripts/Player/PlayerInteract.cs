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
    private bool _isTalked;
    
    private void Awake()
    {
        Init();
    }

    public void Interact(bool isInteracted, bool isPressedEsc)
    {
        Vector3 origin = transform.position + Vector3.down * 0.5f;
        Vector3 direction = transform.forward;
        
        if (isInteracted)
        {
            if (Physics.Raycast(origin, direction, out RaycastHit hit ,_interactDistance))
            {
                if (hit.collider.gameObject.layer == 15 && !_isChestOpened)
                {
                    Chest chest = hit.collider.GetComponentInParent<Chest>();
                    if(chest != null)
                    {
                        TransferManager.Instance.OpenChest(chest);
                        _isChestOpened = true;
                        GameManager.Instance.IsInteracted = true;
                    }
                }
                else if (hit.collider.gameObject.layer == 14 && !_isPortalInteracted)
                {
                    Portal portal = hit.collider.GetComponentInParent<Portal>();
                    if (portal != null)
                    {
                        portal.InteractPortal();
                        _isPortalInteracted = true;
                        GameManager.Instance.IsInteracted = true;
                    }
                }
                else if (hit.collider.gameObject.layer == 16 && !_isTalked)
                {
                    Crafting craftNPC = hit.collider.GetComponentInParent<Crafting>();
                    if (craftNPC != null)
                    {
                        UIManager.Instance.OpenUI(craftNPC.CraftUI.transform.parent.gameObject);
                        _isTalked = true;
                        GameManager.Instance.IsInteracted = true;
                    }
                }
            }
        }

        if (isPressedEsc)
        {
            if (_isChestOpened)
            {
                TransferManager.Instance.CloseChest();
                _isChestOpened = false;
                GameManager.Instance.IsInteracted = false;
            }

            if (_isPortalInteracted)
            {
                UIManager.Instance.CloseUI();
                _isPortalInteracted = false;
                GameManager.Instance.IsInteracted = false;
            }

            if (_isTalked)
            {
                TransferManager.Instance.TransferAllToInventoryInNPC();
                UIManager.Instance.CloseUI();
                _isTalked = false;
                GameManager.Instance.IsInteracted = false;
            }
        }
        
    }
    
    private void Init()
    {
        _isChestOpened = false;
        _isPortalInteracted = false;
        _isTalked = false;
    }
}
