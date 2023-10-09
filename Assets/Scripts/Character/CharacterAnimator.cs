using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public enum AnimationState
    {
        Movement,
        Attack,
        Action,
        Die,
    }

    public enum MovementType
    {
        Idle,
        Run,
    }

    public enum AttackType
    {
        Normal,
        Buff,
    }

    public enum ActionType
    {
        Reload,
        Victory,
        GetHit,
    }

    public enum DieType
    {
        KnowOut,
        Die,
    }


    private Animator ator = null;


    protected AnimationState currentAnimationState;
    protected MovementType currentMovementType;
    protected AttackType currentAttackType;
    protected ActionType currentActionType;
    protected string currentTrigger = "";



    public Animator Ator
    {
        get
        {
            if (ator == null)
                ator = GetComponent<Animator>();
            return ator;
        }
    }

    public bool ApplyRootMotion { get => Ator.applyRootMotion; set => Ator.applyRootMotion = value; }


    public void Initialized()
    {

    }

    public void SetMovement(MovementType type)
    {
        if (currentAnimationState == AnimationState.Movement && currentMovementType == type)
            return;

        SetFloat("MovementType", (int)type);
        SetTrigger("Movement");

        currentAnimationState = AnimationState.Movement;
        currentMovementType = type;
    }

    public void SetAttack(AttackType type)
    {
        if (currentAnimationState == AnimationState.Attack && currentAttackType == type)
            return;

        SetFloat("AttackType", (int)type);
        SetTrigger("Attack");

        currentAnimationState = AnimationState.Attack;
        currentAttackType = type;
    }

    public void SetAction(ActionType type)
    {
        if (currentAnimationState == AnimationState.Action && currentActionType == type)
            return;

        SetFloat("ActionType", (int)type);
        SetTrigger("Action");

        currentAnimationState = AnimationState.Action;
        currentActionType = type;
    }

    public void SetTrigger(string param)
    {
        if (param.Equals(currentTrigger))
            return;

        if (!String.IsNullOrEmpty(currentTrigger))
            Ator.ResetTrigger(currentTrigger);

        Ator.SetTrigger(param);
        currentTrigger = param;
    }

    public void SetBool(string param, bool value)
    {
        Ator.SetBool(param, value);
    }

    public void SetFloat(string param, float value)
    {
        Ator.SetFloat(param, value);
    }
}
