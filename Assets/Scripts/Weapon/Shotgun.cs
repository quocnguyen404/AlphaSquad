using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    private float countTime;

    public override void Attack(Vector3 target)
    {
        if (countTime == 0) 
        {
            GameObject projectile = Instantiate(weaponObject.projectile);
            projectile.transform.position = spawnPoint.position;

            Projectile bullet = projectile.GetComponent<Projectile>();

            bullet.SetSpeed(weaponObject.projectileSpeed);
            bullet.MoveToTarget(target);

            if (weaponObject.currentProjectileAmount > 0)
                weaponObject.currentProjectileAmount--;
        }

        countTime += Time.deltaTime;
        if (countTime >= weaponObject.fireRate)
            countTime = 0;
    }
}
