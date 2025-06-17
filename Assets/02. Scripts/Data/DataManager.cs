using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public GameData GameData;

    public const string fileName = "SaveFile";
    
#if UNITY_EDITOR
    public string path => Path.Combine(Application.dataPath, $"Data/{fileName}");
#else
    public string path => Path.Combine(Application.persistentDataPath, $"Data/{fileName}");
#endif

    public event Action OnFileChanged;
    public event Action OnGameLoaded;
    
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    
    public void SaveData(int slot)
    {
        if (Directory.Exists(Path.GetDirectoryName($"{path}_{slot}")) == false)
        {
            Directory.CreateDirectory(Path.GetDirectoryName($"{path}_{slot}"));
        } 
        string json = JsonUtility.ToJson(GameData);
        File.WriteAllText($"{path}_{slot}",json);

        OnFileChanged?.Invoke();
    }

    public bool ExistData(int slot)
    {
        if (Directory.Exists((Path.GetDirectoryName($"{path}_{slot}"))) == false)
        {
            return false;
        }

        return File.Exists($"{path}_{slot}");
    }
    
    public bool LoadData(int slot)
    {
        if (!ExistData(slot)) return false;

        string json = File.ReadAllText($"{path}_{slot}");
        GameData = JsonUtility.FromJson<GameData>(json);
        OnGameLoaded?.Invoke();
        return true;
    }
}
