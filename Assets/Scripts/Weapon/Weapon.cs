using System.Collections;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    public WeaponSO weaponObject = null;
    public Transform spawnPoint = null;

    public virtual void Attack(Vector3 target)
    {
        
    }

    public virtual void Reload()
    {

    }
}
