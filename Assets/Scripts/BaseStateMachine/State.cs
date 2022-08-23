using System;

namespace BlackAndWhite.Assets.Scripts.BaseStateMachine
{
    public abstract class State
    {
        protected StateMachine _stateMachine;
        protected DateTime _enteringTime;


        protected State(StateMachine stateMachine)
        {
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
