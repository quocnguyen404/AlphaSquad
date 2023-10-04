using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, ICauseDamage
{
    [Header("Configuration")]
    public float moveSpeed = 100f;
    public float destroyAffterTime = 5f;

    [Header("Object Reference")]
    public ParticleSystem projectileFX = null;
    public ParticleSystem hitFX = null;
    public ParticleSystem flashFx = null;


    private Rigidbody rigidBody = null;

    public float Damage => 10f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        this.DelayCall(destroyAffterTime, () => 
        {
            Destroy(gameObject);
        });
    }

    public void SetSpeed(float value) => moveSpeed = value;

    public void MoveToTarget(Vector3 target)
    {
        transform.LookAt(target);
        gameObject.SetActive(true);
        rigidBody.AddForce(transform.forward * moveSpeed);
    }

    protected void OnTriggerEnter(Collider other)
    {
        GameObject col = other.gameObject;
        projectileFX.gameObject.SetActive(false);
        hitFX.gameObject.SetActive(true);
        hitFX.Play();
        Destroy(gameObject);
    }
}
