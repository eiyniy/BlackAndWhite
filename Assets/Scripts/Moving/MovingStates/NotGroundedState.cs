using BlackAndWhite.Assets.Scripts.BaseStateMachine;

namespace BlackAndWhite.Assets.Scripts.Moving.MovingStates
{
    public abstract class NotGroundedState : BaseMovingState
    {
        private const float MaxSpeedFactor = 1f / 3f;
        private const float AccelerationFactor = 1f / 3f;


        public NotGroundedState(Player player, MovingLogic movingLogic, StateMachine stateMachine) :
            base(player, movingLogic, stateMachine)
        {
        }


        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            _player.UpdateVelocity(_movingLogic.Acceleration * AccelerationFactor, _movingLogic.MaxSpeed * MaxSpeedFactor, _horizontalInput);
        }
    }
}