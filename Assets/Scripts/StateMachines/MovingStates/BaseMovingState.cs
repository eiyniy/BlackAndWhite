using BlackAndWhite.Assets.Scripts.StateMachines.Base;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.StateMachines.MovingStates
{
    public class BaseMovingState : State
    {
        protected float _horizontalInput;


        public BaseMovingState(Player player, StateMachine stateMachine) :
            base(player, stateMachine)
        {
        }


        public override void HandleInput()
        {
            base.HandleInput();

            _horizontalInput = Input.GetAxis("Horizontal");
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (_horizontalInput > 0 && _player.transform.rotation.y != 0)
                _player.transform.rotation = new();
            else if (_horizontalInput < 0)
                _player.transform.rotation = new(0f, 180f, 0f, 0f);
        }
    }
}