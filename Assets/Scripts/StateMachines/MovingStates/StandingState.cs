using BlackAndWhite.Assets.Scripts.StateMachines.Base;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.StateMachines.MovingStates
{
    public class StandingState : GroundedState
    {
        public StandingState(Player player, StateMachine stateMachine) :
            base(player, stateMachine)
        {
        }


        public override void HandleInput()
        {
            base.HandleInput();

            if (Input.GetAxis("Horizontal") != 0)
                _stateMachine.ChangeState(_player.Moving);
        }
    }
}
