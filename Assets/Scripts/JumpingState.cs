using UnityEngine;

namespace BlackAndWhite.Assets.Scripts
{
    public class JumpingState : State
    {
        private bool _isForceAdded;
        
        
        public JumpingState(Player player, StateMachine stateMachine) :
            base(player, stateMachine)
        {
        }


        public override void Enter()
        {
            _isForceAdded = false;
            _player.Rb.AddRelativeForce(new Vector2(0, _player.JumpingForce), ForceMode2D.Impulse);
            _isForceAdded = true;
        }

        public override void Exit()
        {
        }

        public override void HandleInput()
        {
        }

        public override void LogicUpdate()
        {
            if (_player.Rb.velocity.y == 0 && _isForceAdded)
                _stateMachine.ChangeState(_player.Standing);
        }

        public override void PhysicsUpdate()
        {
        }
    }
}