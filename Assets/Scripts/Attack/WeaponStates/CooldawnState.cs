using System;
using BlackAndWhite.Assets.Scripts.BaseStateMachine;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.Attack.WeaponStates
{
    public class CooldawnState : BaseWeaponState
    {
        private int _attacksCount;


        private int AttacksCount
        {
            get => _attacksCount;
            set
            {
                _attacksCount = value;

                if (AttacksCount < _weapon.AttackCountsToReload || _weapon.AttackCountsToReload == 0)
                    return;

                _stateMachine.ChangeState(_weapon.Reloading);
                AttacksCount = 0;
            }
        }

        public TimeSpan TimeRemaining
        {
            get
            {
                var timeLeft = DateTime.Now - _enteringTime;
                return timeLeft < _weapon.AttackCooldawn
                    ? _weapon.AttackCooldawn - timeLeft
                    : TimeSpan.Zero;
            }
        }


        public CooldawnState(Weapon weapon, StateMachine stateMachine) :
            base(weapon, stateMachine)
        {
            AttacksCount = 0;
        }


        public override void HandleInput()
        {
            base.HandleInput();

            if (TimeRemaining > TimeSpan.Zero)
                return;

            var isWhiteAttack = Input.GetKey("o");
            var isBlackAttack = Input.GetKey("p");

            if (!(isWhiteAttack || isBlackAttack))
                return;

            if (isWhiteAttack && _weapon.AttackElement != AttackElement.White)
                _weapon.AttackElement = AttackElement.White;
            else if (isBlackAttack && _weapon.AttackElement != AttackElement.Black)
                _weapon.AttackElement = AttackElement.Black;

            _stateMachine.ChangeState(_weapon.Attacking);

            AttacksCount++;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_stateMachine.IsLoggingEnabled)
            {
                if (TimeRemaining > TimeSpan.Zero)
                    Debug.Log($"Cooldawn {TimeRemaining}");
            }
        }
    }
}