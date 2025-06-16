using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class Property<T>
{
    private T _value;

    public T Value
    {
        get { return _value; }
        set
        {
            if(!EqualityComparer<T>.Default.Equals(_value, value))
            {
                _value = value; 
                OnChanged?.Invoke(_value); 
            }
        }
    }
    public event Action<T> OnChanged;

    public Property(T value)
    {
        _value = value;
    }
}
