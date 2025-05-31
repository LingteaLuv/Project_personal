using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffManager : Singleton<StuffManager>
{
    private Dictionary<GameObject, GameObject> _stuffPair;
    private List<GameObject> _stuffList;
    public List<GameObject> StuffList => _stuffList;
    
    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    public void Add(GameObject stuffInMap, GameObject stuffInMinimap)
    {
        _stuffPair.Add(stuffInMap,stuffInMinimap);
        _stuffList.Add(stuffInMinimap);
    }

    public void Remove(GameObject stuffInMap)
    {
        if (_stuffPair.TryGetValue(stuffInMap, out GameObject stuffInMinimap))
        {
            Destroy(stuffInMinimap);
            _stuffPair.Remove(stuffInMap);
            _stuffList.Remove(stuffInMinimap);
        }
    }
    
    private void Init()
    {
        _stuffPair = new Dictionary<GameObject, GameObject>();
        _stuffList = new List<GameObject>();
    }
}
