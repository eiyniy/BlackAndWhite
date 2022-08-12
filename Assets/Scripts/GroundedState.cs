using UnityEngine;

namespace BlackAndWhite.Assets.Scripts
{
    public class GroundedState : State
    {
        public GroundedState(Player player, StateMachine stateMachine) :
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
            if (Input.GetKeyDown("space"))
                _stateMachine.ChangeState(_player.Jumping);
        }

        public override void LogicUpdate()
        {

        }

        public override void PhysicsUpdate()
        {

        }
    }
}