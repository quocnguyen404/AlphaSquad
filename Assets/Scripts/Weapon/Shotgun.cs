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

            Bullet bullet = projectile.GetComponent<Bullet>();

            bullet.SetBulletPooling(bulletPooling);
            bullet.SetSpeed(weaponObject.speed);
            bullet.ShotToTarget(target);
        }

        countTime += Time.deltaTime;
        if (countTime >= weaponObject.fireRate)
            countTime = 0;
    }
}
