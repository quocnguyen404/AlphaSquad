using UnityEngine;


public class Weapon : MonoBehaviour
{
    public WeaponObject weaponObject = null;
    public Transform spawnPoint = null;


    public virtual void Attack(Vector3 target)
    {

    }
}
