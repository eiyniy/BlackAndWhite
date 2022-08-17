using BlackAndWhite.Assets.Scripts.StateMachines.Base;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.StateMachines.MovingStates
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
            if (_player.Rb.velocity.y != 0)
                _stateMachine.ChangeState(_player.Falling);
        }

        public override void PhysicsUpdate()
        {

        }
    }
}