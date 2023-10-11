using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeProjectile : MonoBehaviour, ICauseDamage
{
    [SerializeField] protected GameObject projectile = null;
    [SerializeField] protected ParticleSystem hit = null;
    [SerializeField] protected Rigidbody rigidBody = null;

    protected Vector3 intPos = Vector3.zero;

    private float speed = 0f;
    private float damage = 0f;
    public float Damage => damage;

    private void OnDisable()
    {
        rigidBody.velocity = Vector3.zero;
    }

    public void SetSpeed(float speed) => this.speed = speed;

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void SetPosition(Vector3 pos)
    {
        intPos = pos;
        transform.position = pos;
        projectile.SetActive(true);
    }

    public void MoveToTarget(Vector3 target)
    {
        rigidBody.AddForce(target * speed, ForceMode.Impulse);
        CountDownGrenade(5f);
    }

    public void CountDownGrenade(float time)
    {
        StartCoroutine(CountDown(time));
    }

    IEnumerator CountDown(float time)
    {
        float timer = 0;

        while (timer < time)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        Debug.Log("Booom!!");
        yield return null;
    }


}
