using BlackAndWhite.Assets.Scripts.BaseStateMachine;

namespace BlackAndWhite.Assets.Scripts.Moving.MovingStates
{
    public class MovingState : GroundedState
    {
        private bool _isFirstFrame;


        public MovingState(Player player, MovingLogic movingLogic, StateMachine stateMachine) :
            base(player, movingLogic, stateMachine)
        {
        }


        public override void Enter()
        {
            base.Enter();

            _isFirstFrame = true;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_player.Rb.velocity.x != 0 ||
                _isFirstFrame ||
                _horizontalInput != 0f)
                return;

            _stateMachine.ChangeState(_movingLogic.Standing);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            _player.UpdateVelocity(_movingLogic.Acceleration, _movingLogic.MaxSpeed, _horizontalInput);

            _isFirstFrame = false;
        }
    }
}
