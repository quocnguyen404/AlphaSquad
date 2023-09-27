using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Configuration")]
    public float moveSpeed = 100f;
    public float destroyAffterTime = 5f;

    [Header("Object Reference")]
    public ParticleSystem projectileFX = null;
    public ParticleSystem hitFX = null;
    public ParticleSystem flashFx = null;


    private Rigidbody rigidBody = null;


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
        projectileFX.gameObject.SetActive(false);
        hitFX.gameObject.SetActive(true);
        hitFX.Play();
    }
}
