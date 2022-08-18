using System;
using BlackAndWhite.Assets.Scripts.StateMachines.Base;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.StateMachines.MovingStates
{
    public class JumpingState : NotGroundedState
    {
        private readonly TimeSpan _raycastCooldawn = TimeSpan.FromSeconds(0.5);

        private DateTime _jumpTime;


        public JumpingState(Player player, StateMachine stateMachine) :
            base(player, stateMachine)
        {
        }


        public override void Enter()
        {
            base.Enter();

            _player.Rb.velocity = new Vector2(_player.Rb.velocity.x / 3, 0);
            _player.Rb.AddForce(new Vector2(0, _player.JumpingForce), ForceMode2D.Impulse);

            _jumpTime = DateTime.Now;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (DateTime.Now - _jumpTime < _raycastCooldawn)
                return;

            _stateMachine.ChangeState(_player.Falling);
        }
    }
}