using BlackAndWhite.Assets.Scripts.BaseStateMachine;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.Moving.MovingStates
{
    public class StandingState : GroundedState
    {
        public StandingState(Player player, MovingLogic movingLogic, StateMachine stateMachine) :
            base(player, movingLogic, stateMachine)
        {
        }


        public override void HandleInput()
        {
            base.HandleInput();

            if (Input.GetAxis("Horizontal") != 0)
                _stateMachine.ChangeState(_movingLogic.Moving);
        }
    }
}
