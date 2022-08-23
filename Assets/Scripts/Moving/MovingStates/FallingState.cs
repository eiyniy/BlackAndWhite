using BlackAndWhite.Assets.Scripts.BaseStateMachine;

namespace BlackAndWhite.Assets.Scripts.Moving.MovingStates
{
    public class FallingState : NotGroundedState
    {
        public FallingState(Player player, MovingLogic movingLogic, StateMachine stateMachine) :
            base(player, movingLogic, stateMachine)
        {
        }


        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!_player.IsGrounded())
                return;

            if (_player.Rb.velocity.x == 0)
                _stateMachine.ChangeState(_movingLogic.Standing);
            else
                _stateMachine.ChangeState(_movingLogic.Moving);
        }
    }
}