using System;

namespace BlackAndWhite.Assets.Scripts.StateMachines.Base
{
    public abstract class State
    {
        protected Player _player;
        protected StateMachine _stateMachine;
        protected DateTime _enteringTime;


        protected State(Player player, StateMachine stateMachine)
        {
            _player = player;
            _stateMachine = stateMachine;
        }


        public virtual void Enter() 
        { 
            _enteringTime = DateTime.Now;
        }

        public virtual void HandleInput() { }

        public virtual void LogicUpdate() { }

        public virtual void PhysicsUpdate() { }

        public virtual void Exit() { }
    }
}
