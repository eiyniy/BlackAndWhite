
using System.Linq;
using UnityEngine;

namespace BlackAndWhite.Assets.Scripts.StateMachines.Base
{
    public class StateMachine
    {
        public State CurrentState { get; set; }


        public void Initialize(State startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }

        public void ChangeState(State state)
        {
            Debug.Log($"{state.GetType().ToString().Split('.').TakeLast(2).First()} change state to {state.GetType().ToString().Split('.').Last()}");

            CurrentState.Exit();

            CurrentState = state;
            CurrentState.Enter();
        }
    }
}
