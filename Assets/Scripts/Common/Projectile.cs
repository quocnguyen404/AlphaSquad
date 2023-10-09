using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, ICauseDamage
{
    [Header("Configuration")]
    public float moveSpeed = 100f;

    [Header("Object Reference")]
    public ParticleSystem projectileFX = null;
    public ParticleSystem hitFX = null;
    public ParticleSystem flashFx = null;

    private Vector3 initPos = Vector3.zero;
    private Rigidbody rigidBody = null;
    private readonly float deactiveDistance = 100f;

    private float damage = 0f;
    public float Damage => damage;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (IsBulletDead())
            gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        rigidBody.velocity = Vector3.zero;
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
        projectileFX.gameObject.SetActive(true);
        initPos = pos;
    }

    public void SetSpeed(float value) => moveSpeed = value;

    public void MoveToTarget(Vector3 target)
    {
        transform.LookAt(target);
        projectileFX.gameObject.SetActive(true);
        flashFx.Play();
        rigidBody.AddForce(transform.forward * moveSpeed);
    }

    public bool IsBulletDead()
    {
        bool isDead = false;

        if (Vector3.SqrMagnitude(initPos - transform.position) > deactiveDistance * deactiveDistance)
        {
            isDead = true;
        }

        return isDead;
    }

    protected void OnTriggerEnter(Collider other)
    {
        GameObject col = other.gameObject;
        projectileFX.gameObject.SetActive(false);
        hitFX.gameObject.SetActive(true);
        hitFX.Play();
    }
}
