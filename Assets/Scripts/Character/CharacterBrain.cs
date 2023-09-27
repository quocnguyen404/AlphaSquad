using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBrain : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] protected string characterName;

    [Header("Component System")]
    [SerializeField] protected Agent agent = null;
    [SerializeField] protected CharacterAnimator characterAnimator = null;
    [SerializeField] protected CharacterAttack characterAttack = null;

    [SerializeField] protected CharacterData characterData = null;
    [SerializeField] private float currentHP;
    public bool ALive => currentHP > 0;

    public float maxHP => characterData.attributes.Find(a => a.Type == AttributeType.HP).Value;
    public string Name => characterName;


    protected abstract CharacterBrain targetAttack { get; }
    


    protected virtual void Awake()
    {
        characterData = Resources.Load<CharacterData>("Data/" + name);
        agent.Initialized();
        characterAnimator.Initialized();
        characterAttack.Initialized();

        currentHP = maxHP;
    }



    protected virtual bool CanAttack()
    {
        return targetAttack != null;
    }

    protected void DoAttack()
    {
        agent.RotateToDirection(targetAttack.transform.position - transform.position);
        characterAnimator.SetAttack(CharacterAnimator.AttackType.Normally);
        characterAttack.Attack(targetAttack.transform.position);
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log(name + " take damage");
            currentHP -= 5f;
            Debug.Log(currentHP);

            if (!ALive) 
            {
                characterAnimator.SetTrigger("Die");
            }
        }
    }

}
