using System;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts
{
    public class JumpingState : State
    {
        private Vector2 _dir;
        private bool _isForceAdded;


        public JumpingState(Player player, StateMachine stateMachine) :
            base(player, stateMachine)
        {
        }


        public override void Enter()
        {
            _isForceAdded = false;
            _player.Rb.velocity = new Vector2(_player.Rb.velocity.x / 5, 0);
            _player.Rb.AddForce(new Vector2(0, _player.JumpingForce), ForceMode2D.Impulse);
            _isForceAdded = true;
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
            if (_player.Rb.velocity.y == 0 && _isForceAdded)
                _stateMachine.ChangeState(_player.Standing);
        }

        public override void PhysicsUpdate()
        {
            if (Math.Abs(_player.Rb.velocity.x) >= _player.MaxSpeed / 3 && (_player.Rb.velocity.x * _dir.x) > 0)
                return;

            _player.Rb.velocity += _player.Acceleration / 3 * _dir * Time.deltaTime;
        }
    }
}