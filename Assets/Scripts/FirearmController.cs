using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirearmController : MonoBehaviour
{
    [SerializeField] private Transform _weaponHold;
    [SerializeField] private Firearm _startingFirearm;
    private Firearm _equippedFirearm;

    void Start()
    {
        if (_startingFirearm != null)
            EquipFirearm(_startingFirearm);
    }
    
    public void EquipFirearm(Firearm firarmToEquip)
    {
        if(_equippedFirearm != null)
            Destroy(_equippedFirearm.gameObject);
        _equippedFirearm = Instantiate(firarmToEquip, _weaponHold.position, _weaponHold.rotation) as Firearm;
        _equippedFirearm.transform.parent = _weaponHold;
    }

    public void Shoot()
    {
        if(_equippedFirearm != null)
        {
            _equippedFirearm.Shoot();
        }
    }
}
