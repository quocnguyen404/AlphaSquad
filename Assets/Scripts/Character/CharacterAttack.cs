using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public Weapon currentWeapon = null;

    public void Init()
    {

    }

    public void Attack(Vector3 target)
    {
        currentWeapon.Attack(target);
    }
}
