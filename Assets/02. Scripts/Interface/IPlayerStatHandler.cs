using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerStatHandler
{
    public void ApplyModifier(StatModifier modifier);
    public void RemoveModifier(StatModifier modifier);
}
