using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGun : Weapon
{
    public Transform spawnPoint;
    private float countTime;
    public override void Attack(Vector3 target)
    {
        if (isReloading)
            return;

        if (countTime == 0)
        {
            //GameObject projectile = Instantiate(weaponObject.projectile);
            //GameObject projectile = Pooling.GetProjectile().gameObject;

            Projectile bullet = Pooling.GetProjectile();

            bullet.SetDamage(weaponObject.damage);
            bullet.SetPosition(spawnPoint.position);
            bullet.SetSpeed(weaponObject.projectileSpeed);
            bullet.MoveToTarget(target);

            weaponObject.currentProjectileAmount--;
        }

        countTime += Time.deltaTime;
        if (countTime >= weaponObject.fireRate)
            countTime = 0;
    }

    public override void Reload()
    {
        isReloading = true;
        StartCoroutine(DoReload(weaponObject.reloadTime));
    }
}
