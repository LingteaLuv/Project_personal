using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDetectRangeNotify
{
    public event Action<float> OnDetectRangeChanged;
    public float DetectRange { get; set; }
}
