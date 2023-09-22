using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Object", menuName = "Weapon")]
public class WeaponObject : ScriptableObject
{
    public float fireRate;
    public float damage;
    public float reload;
    public float attackRange;
    public float speed;

    public GameObject projectile;
}
