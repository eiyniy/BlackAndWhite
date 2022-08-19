using System;
using BlackAndWhite.Assets.Scripts.StateMachines.Base;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.StateMachines.MovingStates
{
    public class MovingState : GroundedState
    {
        private bool _isFirstFrame;


        public MovingState(Player player, StateMachine stateMachine) :
            base(player, stateMachine)
        {
        }


        public override void Enter()
        {
            base.Enter();

            _isFirstFrame = true;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_player.Rb.velocity.x != 0 ||
                _isFirstFrame ||
                _horizontalInput != 0f)
                return;

            _stateMachine.ChangeState(_player.Standing);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            _player.UpdateVelocity(_player.Acceleration, _player.MaxSpeed, _horizontalInput);

            _isFirstFrame = false;
        }
    }
}
