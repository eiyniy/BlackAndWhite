using System;
using BlackAndWhite.Assets.Scripts.StateMachines.Base;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.StateMachines.MovingStates
{
    public abstract class GroundedState : State
    {
        private readonly TimeSpan _fallingCooldawn = TimeSpan.FromSeconds(0.5);
        private DateTime _fallingCheckTimer;


        public GroundedState(Player player, StateMachine stateMachine) :
            base(player, stateMachine)
        {
        }


        public override void Enter()
        {
            _fallingCheckTimer = DateTime.Now;
        }

        public override void Exit()
        {
        }

        public override void HandleInput()
        {
            if (Input.GetKeyDown("space"))
                _stateMachine.ChangeState(_player.Jumping);
        }

        public override void LogicUpdate()
        {
            if (_player.Rb.velocity.y == 0 ||
                DateTime.Now - _fallingCheckTimer <= _fallingCooldawn)
                return;

            _fallingCheckTimer = DateTime.Now;
            _stateMachine.ChangeState(_player.Falling);
        }

        public override void PhysicsUpdate()
        {
        }
    }
}