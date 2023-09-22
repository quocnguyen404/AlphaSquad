using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBrain : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] protected string characterName;
    [SerializeField] protected float attackRange = 5f;

    protected float health = 100f;
    protected float timer = 0f;
    protected bool aLive => health > 0;

    protected virtual Transform target { get; set; }

    [Header("Component System")]
    [SerializeField] protected Agent agent = null;
    [SerializeField] protected CharacterAnimator characterAnimator = null;
    [SerializeField] protected CharacterAttack characterAttack = null;


    public string Name => characterName;


    protected virtual void Awake()
    {
        agent.Initialized();
        characterAnimator.Initialized();
        characterAttack.Init();
    }

    protected virtual void Update()
    {
        if (!aLive)
        {
            characterAnimator.SetTrigger("Die");
            return;
        }

        if (CanAttack())
        {
            DoAttack();
            return;
        }
    }

    protected virtual bool CanAttack()
    {
        return false;
    }

    protected void DoAttack()
    {
        agent.RotateToDirection(target.position);
        characterAnimator.SetAttack(CharacterAnimator.AttackType.Powerful);
        characterAttack.Attack(target.position);
    }

    protected void TakeDamage()
    {
        health -= 10f;

        if (health <= 0f)
        {
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
