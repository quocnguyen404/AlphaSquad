using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/NewWeapon")]
public class WeaponSO : ScriptableObject
{
    [Header("Object Reference")]
    public GameObject projectile = null;

    [Header("Comnfiguration")]
    public float attackRange = 10f;
    public float fireRate = 0.2f;
    public float reloadTime = 2f;
    public int currentProjectileAmount = 0;
    public int maxProjectileAmount = 20;
    public float projectileSpeed = 100f;
    public float damage = 10f;
    public WeaponSO()
    {

    }
}
