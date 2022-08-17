using BlackAndWhite.Assets.Scripts.StateMachines.Base;

namespace BlackAndWhite.Assets.Scripts.StateMachines.MovingStates
{
    public class FallingState : NotGroundedState
    {
        public FallingState(Player player, StateMachine stateMachine) :
            base(player, stateMachine)
        {
        }


        public override void Enter()
        {
        }

        public override void Exit()
        {
        }

        public override void HandleInput()
        {
        }

        public override void LogicUpdate()
        {
            if (!_player.IsGrounded())
                return;

            if (_player.Rb.velocity.x == 0)
                _stateMachine.ChangeState(_player.Standing);
            else
                _stateMachine.ChangeState(_player.Moving);
        }

        public override void PhysicsUpdate()
        {
        }
    }
}