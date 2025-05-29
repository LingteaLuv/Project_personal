using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private List<IAttackable> _weaponList;
    private IAttackable _basicWeapon;
    private IAttackable _curWeapon;
    public IAttackable CurWeapon => _curWeapon;

    private int _curIndex;

    private void Awake()
    {
        Init();
    }
    
    public void ChangeWeapon(bool changeLeft, bool changeRight)
    {
        if (changeLeft)
        {
            int index = _curIndex - 1 < 0 ? _weaponList.Count - 1 : _curIndex - 1;
            _curIndex = index;
            _curWeapon = _weaponList[_curIndex];
        }

        if (changeRight)
        {
            int index = _curIndex + 1 > _weaponList.Count - 1 ? 0 : _curIndex + 1;
            _curIndex = index;
            _curWeapon = _weaponList[_curIndex];
        }
    }

    private void Init()
    {
        _weaponList = new List<IAttackable>();
        _basicWeapon = GetComponentInChildren<IAttackable>();
        _weaponList.Add(_basicWeapon);
        _curIndex = 0;
        _curWeapon = _weaponList[_curIndex];
    }
}
