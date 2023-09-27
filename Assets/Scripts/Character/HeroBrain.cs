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
        if (joyStick.Direction == Vector2.zero)
        {
            if (CanAttack())
                DoAttack();
            else
                characterAnimator.SetMovement(CharacterAnimator.MovementType.Idle);
            return;
        }

        characterAnimator.SetMovement(CharacterAnimator.MovementType.Run);
        Vector3 targetDirection = new Vector3(joyStick.Direction.x, 0, joyStick.Direction.y);
        agent.MoveToDirection(targetDirection);
    }

}
