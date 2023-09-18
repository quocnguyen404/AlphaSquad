using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBrain : CharacterBrain
{
    [SerializeField] protected Joystick joyStick = null;





    private void Update()
    {
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
