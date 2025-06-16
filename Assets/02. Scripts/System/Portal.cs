using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [Header("Drag&Drop")]
    private PortalUI _portalUI;
    public PortalUI PortalUI => _portalUI;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        _portalUI = UIBinder.Instance.GetPortalUI();
    }
    
    public void ConnectPortal()
    {
        UIManager.Instance.OpenUI(_portalUI.gameObject);
    }
    
    private void Init()
    {
        
    }
}
