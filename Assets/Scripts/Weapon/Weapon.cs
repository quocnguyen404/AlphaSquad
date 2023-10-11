using System.Collections;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    public WeaponSO weaponObject = null;
    protected ObjectPoolGun pooling = null;
    protected bool isReloading;

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

    protected IEnumerator DoReload(float time)
    {
        float timer = 0f;

        while (timer < time)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        Debug.Log("Done Reload");
        isReloading = false;
        weaponObject.currentProjectileAmount = weaponObject.maxProjectileAmount;

        yield return null;
    }

}
