using BlackAndWhite.Assets.Scripts.StateMachines.Base;

namespace BlackAndWhite.Assets.Scripts.StateMachines.AttackingStates
{
    public class ChargingState : State
    {
        public ChargingState(Player player, StateMachine stateMachine) :
            base(player, stateMachine)
        {
        }
    }
}