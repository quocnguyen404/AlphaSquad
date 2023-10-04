using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyBrain : CharacterBrain
{
    [SerializeField] protected float attackRange => characterAttack.AttackRange;
    [SerializeField] protected virtual float followRange => 5f;

    protected List<Vector3> wayPoints = null;
    protected int currentWaypointIndex = 0;

    protected override CharacterBrain targetAttack => GameManager.Instance.player;

    protected bool arried = false;
    protected bool onFollowPlayer = false;

    protected override void Awake()
    {
        base.Awake();
        wayPoints = GameManager.Instance.enemiesWaypoint.Find(w => w.targetEnemy.Equals(Name))?.points.Select(p => p.position).ToList();
        agent.OnArried = OnArried;
    }

    protected virtual void Update()
    {

        if (!ALive)
            return;

        if (arried)
            return;

        if (CanAttack())
        {
            onFollowPlayer = true;
            agent.AgentBody.isStopped = true;
            DoAttack();
            return;
        }

        if (FollowTarget())
        {
            characterAnimator.SetMovement(CharacterAnimator.MovementType.KnifeRun);
            agent.SetDestination(targetAttack.transform.position);

            return;
        }

        characterAnimator.SetMovement(CharacterAnimator.MovementType.KnifeRun);
        agent.SetDestination(wayPoints[currentWaypointIndex]);
    }

    protected override void DoAttack()
    {
        base.DoAttack();
        characterAnimator.SetAttack(CharacterAnimator.AttackType.KnifeAttack);
    }

    protected virtual bool FollowTarget()
    {
        return targetAttack != null && Vector3.Distance(transform.position, targetAttack.transform.position) < followRange && targetAttack.ALive;
    }

    protected override bool CanAttack()
    {
        if (!canAttack)
            return false;

        if (targetAttack == null)
            return false;

        return Vector3.Distance(transform.position, targetAttack.transform.position) <= attackRange && targetAttack.ALive;
    }

    protected virtual void OnArried()
    {
        arried = true;
        characterAnimator.SetMovement(CharacterAnimator.MovementType.KnifeIdle);
        this.DelayCall(2, () =>
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= wayPoints.Count)
                currentWaypointIndex = 0;
            arried = false;
        });
    }
}
