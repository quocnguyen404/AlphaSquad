using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeroBrain : CharacterBrain
{
    [SerializeField] protected Joystick joyStick = null;

    protected override CharacterBrain targetAttack => GameManager.Instance.enemies.Find(e => Vector3.Distance(transform.position, e.gameObject.transform.position) <= characterAttack.AttackRange);


    protected void Update()
    {

        if (!ALive)
            return;

        if (joyStick.Direction == Vector2.zero)
        {
            if (CanAttack())
            {
                DoAttack();
            }
            else
                characterAnimator.SetMovement(CharacterAnimator.MovementType.ShotgunIdle);
            return;
        }

        characterAnimator.SetMovement(CharacterAnimator.MovementType.ShotgunRun);
        Vector3 targetDirection = new Vector3(joyStick.Direction.x, 0, joyStick.Direction.y);
        agent.MoveToDirection(targetDirection);
    }

    protected override bool CanAttack()
    {
        if (!canAttack)
            return false;

        if (targetAttack == null)
            return false;

        return Vector3.Distance(targetAttack.transform.position, transform.position) <= characterAttack.AttackRange && targetAttack.ALive;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

}
