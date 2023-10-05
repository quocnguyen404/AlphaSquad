using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    private float countTime;
    private bool isReloading;
    public override void Attack(Vector3 target)
    {

        if (isReloading)
            return;

        if (countTime == 0) 
        {
            GameObject projectile = Instantiate(weaponObject.projectile);
            projectile.transform.position = spawnPoint.position;

            Projectile bullet = projectile.GetComponent<Projectile>();

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
        Debug.Log("Reload");
        Invoke("DoneReload", weaponObject.reloadTime);
    }

    protected void DoneReload()
    {
        isReloading = false;
        Debug.Log("Done reload");
        weaponObject.currentProjectileAmount = weaponObject.maxProjectileAmount;
    }
}
