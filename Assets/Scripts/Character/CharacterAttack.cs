using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterAttack : MonoBehaviour
{
    private Weapon currentWeapon = null;
    public float AttackRange => currentWeapon.weaponObject.attackRange;

    public bool IsReload => currentWeapon.weaponObject.currentProjectileAmount == 0;

    private void Awake()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }

    public void Initialized()
    {
        currentWeapon.weaponObject.currentProjectileAmount = currentWeapon.weaponObject.maxProjectileAmount;
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
