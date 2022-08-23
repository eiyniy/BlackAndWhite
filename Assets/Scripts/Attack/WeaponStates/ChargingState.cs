using BlackAndWhite.Assets.Scripts.BaseStateMachine;

namespace BlackAndWhite.Assets.Scripts.Attack.WeaponStates
{
    public class ChargingState : BaseWeaponState
    {
        public ChargingState(Weapon weapon, StateMachine stateMachine) :
            base(weapon, stateMachine)
        {
        }
    }
}