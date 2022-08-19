using System;
using BlackAndWhite.Assets.Scripts.StateMachines.Base;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.StateMachines.MovingStates
{
    public abstract class NotGroundedState : BaseMovingState
    {
        private const float MaxSpeedFactor = 1f / 3f;
        private const float AccelerationFactor = 1f / 3f;


        public NotGroundedState(Player player, StateMachine stateMachine) :
            base(player, stateMachine)
        {
        }


        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            _player.UpdateVelocity(_player.Acceleration * AccelerationFactor, _player.MaxSpeed * MaxSpeedFactor, _horizontalInput);
        }
    }
}