using BlackAndWhite.Assets.Scripts.BaseStateMachine;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.Moving.MovingStates
{
    public class BaseMovingState : BaseMoveState
    {
        protected float _horizontalInput;


        public BaseMovingState(Player player, MovingLogic movingLogic, StateMachine stateMachine) :
            base(player, movingLogic, stateMachine)
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