using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon = null;

    public float AttackRange => currentWeapon.weaponObject.attackRange;

    public bool IsReload => currentWeapon.weaponObject.currentProjectileAmount == 0;

    public void Initialized()
    {
        GetCurrentWeapon();
        currentWeapon.weaponObject.currentProjectileAmount = currentWeapon.weaponObject.maxProjectileAmount;
    }

    private void GetCurrentWeapon()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }

    public void Attack(Vector3 target)
    {
        currentWeapon.Attack(target);
    }

    public void Reload()
    {
        currentWeapon.Reload();
    }
}
