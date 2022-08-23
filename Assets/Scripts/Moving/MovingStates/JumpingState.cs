using System;
using BlackAndWhite.Assets.Scripts.BaseStateMachine;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.Moving.MovingStates
{
    public class JumpingState : NotGroundedState
    {
        private readonly TimeSpan _raycastCooldawn = TimeSpan.FromSeconds(0.5);

        private DateTime _jumpTime;


        public JumpingState(Player player, MovingLogic movingLogic, StateMachine stateMachine) :
            base(player, movingLogic, stateMachine)
        {
        }


        public override void Enter()
        {
            base.Enter();

            _player.Rb.velocity = new Vector2(_player.Rb.velocity.x / 3, 0);
            _player.Rb.AddForce(new Vector2(0, _movingLogic.JumpingForce), ForceMode2D.Impulse);

            _jumpTime = DateTime.Now;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (DateTime.Now - _jumpTime < _raycastCooldawn)
                return;

            _stateMachine.ChangeState(_movingLogic.Falling);
        }
    }
}