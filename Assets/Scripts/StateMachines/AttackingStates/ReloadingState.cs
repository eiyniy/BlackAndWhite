using System;
using BlackAndWhite.Assets.Scripts.StateMachines.Base;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.StateMachines.AttackingStates
{
    public class ReloadingState : State
    {
        private DateTime _reloadTimer;


        public ReloadingState(Player player, StateMachine stateMachine) :
            base(player, stateMachine)
        {
        }


        public TimeSpan TimeRemaining
        {
            get
            {
                var timeLeft = DateTime.Now - _reloadTimer;
                return timeLeft < _player.ReloadingTime
                    ? _player.ReloadingTime - timeLeft
                    : TimeSpan.Zero;
            }
        }


        public override void Enter()
        {
            base.Enter();
            
            _reloadTimer = DateTime.Now;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_stateMachine.IsLoggingEnabled)
            {
                if (TimeRemaining > TimeSpan.Zero)
                    Debug.Log($"Reloading {TimeRemaining}");
            }

            if (TimeRemaining > TimeSpan.Zero)
                return;

            _stateMachine.ChangeState(_player.Cooldawn);
        }
    }
}