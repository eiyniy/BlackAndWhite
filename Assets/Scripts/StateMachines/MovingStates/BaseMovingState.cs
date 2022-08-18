using System;
using BlackAndWhite.Assets.Scripts.StateMachines.Base;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.StateMachines.MovingStates
{
    public class BaseMovingState : State
    {
        private bool _isRotateNeeded;

        protected float _horizontalInput;


        public BaseMovingState(Player player, StateMachine stateMachine) :
            base(player, stateMachine)
        {
        }


        public override void HandleInput()
        {
            base.HandleInput();
            
            _horizontalInput = Input.GetAxis("Horizontal");

            if (_horizontalInput != 0f)
            {
                var currRotationY = _player.transform.rotation.y;
                _isRotateNeeded = (currRotationY * _horizontalInput) < 0;
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            
            if (_isRotateNeeded)
            {
                _player.transform.Rotate(new(0f, 180f, 0f));
                _isRotateNeeded = false;
            }
        }
    }
}