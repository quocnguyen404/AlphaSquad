using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBrain : MonoBehaviour
{
    [Header("Component System")]
    [SerializeField] protected Agent agent = null;
    [SerializeField] protected CharacterAnimator characterAnimator = null;
    [SerializeField] protected CharacterAttack characterAttack = null;
    [SerializeField] protected CharacterData characterData = null;
    [SerializeField] protected Healthbar healthbar = null;

    [SerializeField] protected string _name;

    [Header("Debug")]
    [SerializeField] protected bool canAttack;

    [SerializeField] private float currentHP;
    public bool ALive => currentHP > 0;

    public CharacterData CharacterData
    {
        get
        {
            if (characterData == null)
                characterData = Resources.Load<CharacterData>("CharacterData/" + _name);

            return characterData;
        }
    }

    public float maxHP => CharacterData.attributes.Find(a => a.Type == AttributeType.HP).Value;
    public string Name => CharacterData._name;


    protected virtual CharacterBrain targetAttack { get; }



    protected virtual void Awake()
    {
        agent.Initialized();
        characterAnimator.Initialized();
        characterAttack.Initialized();
        healthbar.InitHealthbar(maxHP);

        currentHP = maxHP;
    }

    protected virtual bool CanAttack()
    {
        return targetAttack != null;
    }

    protected virtual void DoAttack()
    {
        if (!characterAttack.IsReload)
        {
            agent.RotateToDirection(targetAttack.transform.position - transform.position);
            characterAnimator.SetAttack(CharacterAnimator.AttackType.ShotgunAttack);
            characterAttack.Attack(targetAttack.transform.position);
        }
        else
            DoReload();

    }

    protected virtual void DoReload()
    {
        characterAnimator.SetAction(CharacterAnimator.ActionType.ShotgunReload);
        characterAttack.Reload();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        ICauseDamage causeDamage = other.GetComponent<ICauseDamage>();

        if (causeDamage != null)
        {
            //Debug.Log(name + " take damage");
            currentHP -= causeDamage.Damage;
            healthbar.HealthbarOnChangeValue(currentHP);
        }
    }

}
