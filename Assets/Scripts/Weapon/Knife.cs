using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon, ICauseDamage
{
    public float Damage { get => weaponObject.damage; }

    public override void Attack(Vector3 target)
    {

    }

}
