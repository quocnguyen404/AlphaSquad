using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleGun : Weapon
{
    float countTime;
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    public override void Attack(Vector3 target)
    {
        if (isReloading)
            return;

        if (countTime == 0)
        {
            Projectile projectile1 = Pooling.GetProjectile();
            Projectile projectile2 = Pooling.GetProjectile();

            projectile1.SetDamage(weaponObject.damage);
            projectile2.SetDamage(weaponObject.damage);

            projectile1.SetPosition(spawnPoint1.position);
            projectile2.SetPosition(spawnPoint2.position);

            projectile1.SetSpeed(weaponObject.projectileSpeed);
            projectile2.SetSpeed(weaponObject.projectileSpeed);

            projectile1.MoveToTarget(target);
            projectile2.MoveToTarget(target);

            weaponObject.currentProjectileAmount -= 2;
        }

        countTime += Time.deltaTime;

        if (countTime >= weaponObject.fireRate)
            countTime = 0;


    }

    public override void Reload()
    {
        StartCoroutine(DoReload(weaponObject.reloadTime));
    }
}
