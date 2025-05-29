using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpeedNotify
{
    public event Action<float> OnSpeedChanged;
    public float Speed { get; set; }
}
