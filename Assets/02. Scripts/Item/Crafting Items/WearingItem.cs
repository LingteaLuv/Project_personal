using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearingItem : MonoBehaviour
{
    protected IPlayerStatHandler _handler;
    protected StatModifier _modifier;
    private bool _isActivated;
    public bool IsActivated => _isActivated;
    
    public virtual void Activate()
    {
        if (!_isActivated)
        {
            _handler.ApplyModifier(_modifier);
            _isActivated = true;
        }
    }

    public virtual void Deactivate()
    {
        if (_isActivated)
        {
            _handler.RemoveModifier(_modifier);
            _isActivated = false;
        }
    }
}
