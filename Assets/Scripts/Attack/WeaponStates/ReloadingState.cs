using System;
using BlackAndWhite.Assets.Scripts.BaseStateMachine;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.Attack.WeaponStates
{
    public class ReloadingState : BaseWeaponState
    {
        private DateTime _reloadTimer;


        public ReloadingState(Weapon weapon, StateMachine stateMachine) :
            base(weapon, stateMachine)
        {
        }


        public TimeSpan TimeRemaining
        {
            get
            {
                var timeLeft = DateTime.Now - _reloadTimer;
                return timeLeft < _weapon.ReloadingTime
                    ? _weapon.ReloadingTime - timeLeft
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

            _stateMachine.ChangeState(_weapon.Cooldawn);
        }
    }
}