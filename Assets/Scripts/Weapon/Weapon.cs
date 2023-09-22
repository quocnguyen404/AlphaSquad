using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public WeaponObject weaponObject = null;
    [SerializeField] protected Transform spawnPoint = null;
    [SerializeField] protected Transform bulletPooling = null;

    public virtual void Attack(Vector3 target)
    {

    }

}
