using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyBrain : CharacterBrain
{

    [Header("Attack")]
    [SerializeField] protected float attackRange = 5f;


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
        if (arried)
            return;

        if (targetAttack != null && Vector3.Distance(transform.position, targetAttack.transform.position) <= attackRange)
        {
            onFollowPlayer = true;
            agent.AgentBody.isStopped = true;
            DoAttack();
            return;
        }

        if (onFollowPlayer && targetAttack != null && Vector3.Distance(transform.position, targetAttack.transform.position) > attackRange)
        {
            characterAnimator.SetMovement(CharacterAnimator.MovementType.Run);
            agent.SetDestination(targetAttack.transform.position);
            return;
        }

        characterAnimator.SetMovement(CharacterAnimator.MovementType.Run);
        agent.SetDestination(wayPoints[currentWaypointIndex]);
    }

    protected virtual void OnArried()
    {
        arried = true;
        characterAnimator.SetMovement(CharacterAnimator.MovementType.Idle);
        this.DelayCall(2, () =>
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= wayPoints.Count)
                currentWaypointIndex = 0;
            arried = false;
        });
    }
}
