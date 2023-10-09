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

    private Rigidbody rigidBody = null;
    private readonly float deactiveDistance = 10f;

    public float Damage => 10f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (IsBulletDead())
            gameObject.SetActive(false);
    }

    public void SetSpeed(float value) => moveSpeed = value;

    public void MoveToTarget(Vector3 target)
    {
        transform.LookAt(target);
        gameObject.SetActive(true);
        flashFx.Play();
        rigidBody.AddForce(transform.forward * moveSpeed);
    }

    public bool IsBulletDead()
    {
        bool isDead = false;

        if (Vector3.SqrMagnitude(Vector3.zero - transform.position) > deactiveDistance * deactiveDistance)
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
