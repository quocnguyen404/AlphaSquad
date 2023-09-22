using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyBrain : CharacterBrain
{

    [Header("Attack")]
    [SerializeField] protected float followRange = 10f;


    protected List<Vector3> wayPoints = null;
    protected int currentWaypointIndex = 0;

    protected override Transform target => GameManager.Instance.player.transform;

    protected bool arried = false;

    protected override void Awake()
    {
        base.Awake();
        wayPoints = GameManager.Instance.enemiesWaypoint.Find(w => w.targetEnemy.Equals(Name))?.points.Select(p => p.position).ToList();
        agent.OnArried = OnArried;
    }

    protected override void Update()
    {
        base.Update();

        if (arried)
            return;

        if (FollowPlayer())
        {
            characterAnimator.SetMovement(CharacterAnimator.MovementType.Run);
            agent.MoveToDestination(target.position);
            return;
        }

        characterAnimator.SetMovement(CharacterAnimator.MovementType.Run);
        agent.MoveToDestination(wayPoints[currentWaypointIndex]);
    }

    protected virtual bool FollowPlayer()
    {
        return Vector3.Distance(transform.position, target.position) <= followRange;
    }

    protected override bool CanAttack()
    {
        return Vector3.Distance(transform.position, target.position) <= attackRange;
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
