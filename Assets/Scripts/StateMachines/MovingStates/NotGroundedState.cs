using System;
using BlackAndWhite.Assets.Scripts.StateMachines.Base;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.StateMachines.MovingStates
{
    public abstract class NotGroundedState : State
    {
        private Vector2 _dir;


        public NotGroundedState(Player player, StateMachine stateMachine) :
            base(player, stateMachine)
        {
        }


        public override void Enter()
        {
        }

        public override void Exit()
        {
        }

        public override void HandleInput()
        {
            _dir = new Vector2(Input.GetAxis("Horizontal"), 0).normalized;
        }

        public override void LogicUpdate()
        {
        }

        public override void PhysicsUpdate()
        {
            if (Math.Abs(_player.Rb.velocity.x) >= _player.MaxSpeed / 3 && (_player.Rb.velocity.x * _dir.x) > 0)
                return;

            _player.Rb.velocity += _player.Acceleration / 3 * _dir * Time.deltaTime;
        }
    }
}