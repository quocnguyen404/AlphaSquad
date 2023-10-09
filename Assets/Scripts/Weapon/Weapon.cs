using System.Collections;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    public WeaponSO weaponObject = null;
    public Transform spawnPoint = null;
    protected ObjectPoolGun pooling = null;

    public ObjectPoolGun Pooling
    {
        get
        {
            if (pooling == null)
                pooling = FindObjectOfType<ObjectPoolGun>();

            return pooling;
        }
    }

    public virtual void Attack(Vector3 target)
    {
        
    }

    public virtual void Reload()
    {

    }
}
