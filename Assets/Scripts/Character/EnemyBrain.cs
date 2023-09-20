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

    protected Transform player => GameManager.Instance.player.transform;

    protected bool arried = false;
    protected bool onFollowPlayer = false;
    protected bool onAttackPlayer = false;

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

        onFollowPlayer = Vector3.Distance(transform.position, player.position) <= followRange;
        onAttackPlayer = Vector3.Distance(transform.position, player.position) <= attackRange;
        
        if (onAttackPlayer)
        {
            characterAnimator.SetAttack(CharacterAnimator.AttackType.Powerful);
            Vector3 dir = player.position - transform.position;
            agent.RotateToDirection(dir);

            timer += Time.deltaTime;

            if (timer >= reload)
            {
                Shot(dir);
                timer = 0f;
            }
            return;
        }

        if (onFollowPlayer)
        {
            characterAnimator.SetMovement(CharacterAnimator.MovementType.Run);
            agent.MoveToDestination(player.position);
            return;
        }


        characterAnimator.SetMovement(CharacterAnimator.MovementType.Run);
        agent.MoveToDestination(wayPoints[currentWaypointIndex]);
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

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Bullet")
    //    {
    //        TakeDamage();
    //        Debug.Log(name + "take damage");
    //    }
    //}
}
