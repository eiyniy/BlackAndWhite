using UnityEngine;

namespace BlackAndWhite.Assets.Scripts
{
    public abstract class State
    {
        protected Player _player;
        protected StateMachine _stateMachine;


        protected State(Player player, StateMachine stateMachine)
        {
            _player = player;
            _stateMachine = stateMachine;
        }


        public abstract void Enter();

        public abstract void HandleInput();

        public abstract void LogicUpdate();

        public abstract void PhysicsUpdate();

        public abstract void Exit();
    }
}
