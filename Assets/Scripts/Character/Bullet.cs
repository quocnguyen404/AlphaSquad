using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    [SerializeField] private float destroyAfterTime = 5f;

    [SerializeField] private ParticleSystem projectile = null;
    [SerializeField] private ParticleSystem hit = null;
    [SerializeField] private ParticleSystem flash = null;

    [SerializeField] private Rigidbody rb = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        this.DelayCall(destroyAfterTime, () =>
        {
            Destroy(gameObject);
        });
    }

    public void SetSpeed(float speed) => this.speed = speed; 

    public void ShotToTarget(Vector3 target)
    {
        transform.LookAt(target);
        gameObject.SetActive(true);
        rb.AddForce(transform.forward * speed);
    }

    public void SetBulletPooling(Transform pool)
    {
        transform.SetParent(pool);
    }

    private void OnTriggerEnter(Collider other)
    {
        projectile.gameObject.SetActive(false);
        hit.gameObject.SetActive(true);
        hit.Play();
    }
}
