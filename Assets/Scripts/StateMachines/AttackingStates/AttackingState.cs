using BlackAndWhite.Assets.Scripts.StateMachines.Base;

namespace BlackAndWhite.Assets.Scripts.StateMachines.AttackingStates
{
    public class AttackingState : State
    {
        public AttackingState(Player player, StateMachine stateMachine) :
            base(player, stateMachine)
        {
        }


        public override void Enter()
        {
            base.Enter();
            
            _stateMachine.ChangeState(_player.Cooldawn);
        }
    }
}