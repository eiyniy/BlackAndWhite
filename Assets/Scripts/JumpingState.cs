using System;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts
{
    public class JumpingState : State
    {
        private readonly TimeSpan _raycastCooldawn = TimeSpan.FromSeconds(0.5);
        
        private Vector2 _dir;
        private DateTime _jumpTime;


        public JumpingState(Player player, StateMachine stateMachine) :
            base(player, stateMachine)
        {
        }


        public override void Enter()
        {
            if (Input.GetKey("w"))
            {
                _player.Rb.velocity = new Vector2(_player.Rb.velocity.x / 5, 0);
                _player.Rb.AddForce(new Vector2(0, _player.JumpingForce), ForceMode2D.Impulse);
            }
            else
                _player.Rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * _player.JumpingForce / 3, _player.JumpingForce / 2), ForceMode2D.Impulse);

            _jumpTime = DateTime.Now;
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
            if (!_player.IsGrounded() || DateTime.Now - _jumpTime < _raycastCooldawn)
                return;

            if (_player.Rb.velocity.x == 0)
                _stateMachine.ChangeState(_player.Standing);
            else
                _stateMachine.ChangeState(_player.Moving);
        }

        public override void PhysicsUpdate()
        {
            if (Math.Abs(_player.Rb.velocity.x) >= _player.MaxSpeed / 3 && (_player.Rb.velocity.x * _dir.x) > 0)
                return;

            _player.Rb.velocity += _player.Acceleration / 3 * _dir * Time.deltaTime;
        }
    }
}