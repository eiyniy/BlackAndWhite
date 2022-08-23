using BlackAndWhite.Assets.Scripts.BaseStateMachine;

namespace BlackAndWhite.Assets.Scripts.Moving.MovingStates
{
    public abstract class BaseMoveState : State
    {
        protected Player _player;
        protected MovingLogic _movingLogic;


        public BaseMoveState(Player player, MovingLogic movingLogic, StateMachine stateMachine) : base(stateMachine)
        {
            _player = player;
            _movingLogic = movingLogic;
        }
    }
}