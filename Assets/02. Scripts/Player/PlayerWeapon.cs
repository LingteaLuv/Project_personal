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
            _curWeapon.Deactivate();
            int index = _curIndex - 1 < 0 ? _weaponList.Count - 1 : _curIndex - 1;
            _curIndex = index;
            _curWeapon = _weaponList[_curIndex];
            _curWeapon.Activate();
        }

        if (changeRight)
        {
            _curWeapon.Deactivate();
            int index = _curIndex + 1 > _weaponList.Count - 1 ? 0 : _curIndex + 1;
            _curIndex = index;
            _curWeapon = _weaponList[_curIndex];
            _curWeapon.Activate();
        }
    }

    public void AddWeapon(IAttackable weapon)
    {
        _weaponList.Add(weapon);
    }
    
    public void RemoveWeapon(IAttackable weapon)
    {
        _weaponList.Remove(weapon);
    }

    private void ChangeToBaseWeapon()
    {
        _curWeapon.Deactivate();
        _curIndex = 0;
        _curWeapon = _weaponList[_curIndex];
        _curWeapon.Activate();
    }
    
    private void HandleGrenadeUsed(Grenade grenade)
    {
        RemoveWeapon(grenade);
        ChangeToBaseWeapon();
    }

    public void EquipBow()
    {
        Bow_T bow = GetComponentInChildren<Bow_T>();
        if (bow != null)
        {
            AddWeapon(bow);
        }
    }

    public void EquipGrenade()
    {
        Grenade grenade = GetComponentInChildren<Grenade>();
        if (grenade != null)
        {
            AddWeapon(grenade);
            grenade.OnUsed += HandleGrenadeUsed;
        }
    }
    
    private void Init()
    {
        _weaponList = new List<IAttackable>();
        _basicWeapon = GetComponentInChildren<Fist>();
        _weaponList.Add(_basicWeapon);
        _curIndex = 0;
        _curWeapon = _weaponList[_curIndex];
        _curWeapon.Activate();
    }
}
