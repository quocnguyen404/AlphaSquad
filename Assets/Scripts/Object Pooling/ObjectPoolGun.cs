using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolGun : ObjectPoolBase
{
    [SerializeField] protected Projectile projectilePref = null;


    protected readonly List<Projectile> projectiles = new List<Projectile>();

    private void Start()
    {
        if (projectiles == null)
            Debug.Log("Projectile prefab is null");
    }

    private void GenerateProjectile()
    {
        Projectile newProjectile = Instantiate(projectilePref, transform);
        newProjectile.gameObject.SetActive(false);

        projectiles.Add(newProjectile);
    }

    public Projectile GetProjectile()
    {
        foreach (Projectile pj in projectiles)
        {
            if (!pj.gameObject.activeInHierarchy)
            {
                pj.gameObject.SetActive(true);
                return pj;
            }
        }

        if (projectiles.Count < MAX_POOL_SIZE)
        {
            GenerateProjectile();

            projectiles[^1].gameObject.SetActive(true);

            return projectiles[^1];
        }

        return null;
    }
}
