
using System.Linq;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.BaseStateMachine
{
    public class StateMachine
    {
        public State CurrentState { get; set; }

        public bool IsLoggingEnabled { get; set; } = false;


        public void Initialize(State startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }

        public void ChangeState(State state)
        {
            if (IsLoggingEnabled)
            {
                var typeNames = state.GetType().ToString().Split('.');
                Debug.Log($"{typeNames.TakeLast(2).First()} change state to {typeNames.Last()}");
            }

            CurrentState.Exit();

            CurrentState = state;
            CurrentState.Enter();
        }
    }
}
