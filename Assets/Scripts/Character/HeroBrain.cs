using System.Collections;
using System.Collections.Generic;
using UnityEditor.DeviceSimulation;
using UnityEngine;

public class HeroBrain : CharacterBrain
{
    [SerializeField] protected Joystick joyStick = null;

    protected Transform enemy
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

        if (enemy != null)
            onAttack = Vector3.Distance(transform.position, enemy.transform.position) <= attackRange;

        if (joyStick.Direction != Vector2.zero)
            onAttack = false;

        if (onAttack)
        {
            characterAnimator.SetAttack(CharacterAnimator.AttackType.Buff);
            Vector3 dir = enemy.position - transform.position;
            agent.RotateToDirection(dir);

            timer += Time.deltaTime;
            if (timer >= reload)
            {
                Shot(dir);
                timer = 0f;
            }

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

    
}
