using BlackAndWhite.Assets.Scripts.BaseStateMachine;

namespace BlackAndWhite.Assets.Scripts.Attack.WeaponStates
{
    public abstract class BaseWeaponState : State
    {
        protected Weapon _weapon;


        public BaseWeaponState(Weapon weapon, StateMachine stateMachine) : base(stateMachine)
        {
            _weapon = weapon;
        }
    }
}