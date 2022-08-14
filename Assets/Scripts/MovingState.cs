using System;
using System.Timers;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts
{
    public class MovingState : GroundedState
    {
        private Vector2 _dir;
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

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();

            _dir = new Vector2(Input.GetAxis("Horizontal"), 0).normalized;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_player.Rb.velocity.x == 0 && !_isFirstFrame)
                _stateMachine.ChangeState(_player.Standing);
        }

        public override void PhysicsUpdate()
        {
            if (Math.Abs(_player.Rb.velocity.x) >= _player.MaxSpeed && (_player.Rb.velocity.x * _dir.x) > 0)
                return;
    
            _player.Rb.velocity += _player.Acceleration * _dir * Time.deltaTime;
            _isFirstFrame = false;

            base.PhysicsUpdate();
        }
    }
}
