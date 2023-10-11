using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : ThrowWeapon
{
    float countTime;

    public override void Attack(Vector3 target)
    {
        if (isReloading)
            return;

        if (countTime == 0)
        {
            GameObject projectile = Instantiate(weaponObject.projectile, transform);

            GrenadeProjectile grenadeProj = projectile.GetComponent<GrenadeProjectile>();

            grenadeProj.SetPosition(spawnPoint.position);
            grenadeProj.SetSpeed(weaponObject.projectileSpeed);
            grenadeProj.SetDamage(weaponObject.damage);
            grenadeProj.MoveToTarget(target);
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
