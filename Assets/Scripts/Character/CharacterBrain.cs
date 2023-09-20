using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBrain : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] protected string characterName;
    [SerializeField] protected float attackRange = 5f;
    [SerializeField] protected Transform gun = null;
    [SerializeField] protected GameObject bullet = null;
    [SerializeField] protected Transform bulletPooling = null;
    [SerializeField] protected float reload = 0.5f;
    [SerializeField] protected float bulletSpeed = 10f;

    protected float health = 100f;
    protected float timer = 0f;

    [Header("Component System")]
    [SerializeField] protected Agent agent = null;
    [SerializeField] protected CharacterAnimator characterAnimator = null;


    public string Name => characterName;


    protected virtual void Awake()
    {
        agent.Initialized();
        characterAnimator.Initialized();
    }

    protected void Shot(Vector3 dir)
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = gun.position;
        newBullet.transform.parent = bulletPooling;
        newBullet.GetComponent<Rigidbody>().AddForce(dir * bulletSpeed);
    }

    protected void TakeDamage()
    {
        health -= 10f;

        if (health <= 0f)
        {
            characterAnimator.SetTrigger("Die");
            Debug.Log(name + " die");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            TakeDamage();
            Debug.Log(name + "take damage");
        }
    }


}
