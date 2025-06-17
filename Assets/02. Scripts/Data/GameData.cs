using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System. Serializable]
public class GameData
{
    public bool HasBackpack;
    public bool HasCompass;
    public bool HasLantern;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        HasBackpack = true;
        HasCompass = true;
        HasLantern = true;
    }
}
