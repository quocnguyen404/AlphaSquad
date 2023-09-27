using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapon/CreateWeapon")]
public class WeaponObject : ScriptableObject
{
    [Header("Object Reference")]
    public GameObject projectile = null;

    [Header("Comnfiguration")]
    public float attackRange = 10f;
    public float fireRate = 0.2f;
    public float reloadTime = 2f;
    public float projectileSpeed = 100f;

    public WeaponObject()
    {

    }
}
