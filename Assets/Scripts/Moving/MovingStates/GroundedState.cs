using System;
using BlackAndWhite.Assets.Scripts.BaseStateMachine;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.Moving.MovingStates
{
    public abstract class GroundedState : BaseMovingState
    {
        private readonly TimeSpan _fallingCooldawn = TimeSpan.FromSeconds(0.5);
        private DateTime _fallingCheckTimer;


        public GroundedState(Player player, MovingLogic movingLogic, StateMachine stateMachine) :
            base(player, movingLogic, stateMachine)
        {
        }


        public override void Enter()
        {
            base.Enter();
            
            _fallingCheckTimer = DateTime.Now;
        }

        public override void HandleInput()
        {
            base.HandleInput();
            
            if (!Input.anyKeyDown)
                return;

            if (Input.GetKeyDown("space"))
                _stateMachine.ChangeState(_movingLogic.Jumping);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            Debug.Log(_player);
            Debug.Log(_player?.Rb);
            Debug.Log(_player?.Rb?.velocity);
            
            if (_player.Rb.velocity.y == 0 ||
                DateTime.Now - _fallingCheckTimer <= _fallingCooldawn)
                return;

            _fallingCheckTimer = DateTime.Now;
            _stateMachine.ChangeState(_movingLogic.Falling);
        }
    }
}