using BlackAndWhite.Assets.Scripts.BaseStateMachine;

namespace BlackAndWhite.Assets.Scripts.Attack.WeaponStates
{
    public class AttackingState : BaseWeaponState
    {
        public AttackingState(Weapon weapon, StateMachine stateMachine) :
            base(weapon, stateMachine)
        {
        }


        public override void Enter()
        {
            base.Enter();
            
            _stateMachine.ChangeState(_weapon.Cooldawn);
        }
    }
}