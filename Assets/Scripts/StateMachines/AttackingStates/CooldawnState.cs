using System;
using BlackAndWhite.Assets.Scripts.Attack;
using BlackAndWhite.Assets.Scripts.StateMachines.Base;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.StateMachines.AttackingStates
{
    public class CooldawnState : State
    {
        private int _attacksCount;


        private int AttacksCount
        {
            get => _attacksCount;
            set
            {
                _attacksCount = value;

                if (AttacksCount < _player.AttackCountsToReload || _player.AttackCountsToReload == 0)
                    return;

                _stateMachine.ChangeState(_player.Reloading);
                AttacksCount = 0;
            }
        }

        public AttackType CurrAttackType { get; set; }

        public TimeSpan TimeRemaining
        {
            get
            {
                var timeLeft = DateTime.Now - _enteringTime;
                return timeLeft < _player.AttackCooldawn
                    ? _player.AttackCooldawn - timeLeft
                    : TimeSpan.Zero;
            }
        }


        public CooldawnState(Player player, StateMachine stateMachine) :
            base(player, stateMachine)
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

            if (isWhiteAttack)
                CurrAttackType = AttackTypesProvider.AttackWhite;
            else if (isBlackAttack)
                CurrAttackType = AttackTypesProvider.AttackBlack;

            _stateMachine.ChangeState(_player.Attacking);

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