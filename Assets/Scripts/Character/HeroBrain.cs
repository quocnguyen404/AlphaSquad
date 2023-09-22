using System.Collections;
using System.Collections.Generic;
using UnityEditor.DeviceSimulation;
using UnityEngine;

public class HeroBrain : CharacterBrain
{
    [SerializeField] protected Joystick joyStick = null;

    protected override Transform target
    {
        get
        {
            EnemyBrain en = null;
            float min = attackRange;

            foreach (EnemyBrain enemy in GameManager.Instance.enemies)
            {
                float dis = min = Vector3.Distance(enemy.transform.position, transform.position);
                if (dis <= min)
                {
                    en = enemy;
                    min = dis;
                }
            }

            return en.transform;
        }
    }
    protected bool onAttack = false;

    protected override void Update()
    {
        base.Update();

        if (target != null)
            onAttack = Vector3.Distance(transform.position, target.transform.position) <= attackRange;

        if (joyStick.Direction != Vector2.zero)
            onAttack = false;

        if (onAttack && CanAttack())
        {
            characterAnimator.SetAttack(CharacterAnimator.AttackType.Buff);
            Vector3 dir = target.position - transform.position;
            agent.RotateToDirection(dir);

            DoAttack();

            return;
        }

        if (joyStick.Direction == Vector2.zero)
        {
            characterAnimator.SetMovement(CharacterAnimator.MovementType.Idle);
            return;
        }

        characterAnimator.SetMovement(CharacterAnimator.MovementType.Run);
        Vector3 targetDirection = new Vector3(joyStick.Direction.x, 0, joyStick.Direction.y);
        agent.MoveToDirection(targetDirection);
    }

    protected override bool CanAttack()
    {
        bool canAttack = true;

        canAttack = aLive;
        canAttack = target != null;
        canAttack = Vector3.Distance(transform.position, target.position) <= characterAttack.currentWeapon.weaponObject.attackRange;

        return canAttack;
    }
}
