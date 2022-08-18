using System;
using BlackAndWhite.Assets.Scripts.StateMachines.Base;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.StateMachines.MovingStates
{
    public abstract class NotGroundedState : BaseMovingState
    {
        public NotGroundedState(Player player, StateMachine stateMachine) :
            base(player, stateMachine)
        {
        }


        public override void PhysicsUpdate()
        {
            if (Math.Abs(_player.Rb.velocity.x) >= _player.MaxSpeed / 3 && (_player.Rb.velocity.x * _horizontalInput) > 0)
                return;

            _player.Rb.velocity += _player.Acceleration / 3 * new Vector2(_horizontalInput, 0f) * Time.deltaTime;
        }
    }
}