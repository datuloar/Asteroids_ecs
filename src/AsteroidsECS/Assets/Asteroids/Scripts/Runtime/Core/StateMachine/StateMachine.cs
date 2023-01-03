using System;
using System.Collections.Generic;
using Zenject;

namespace Asteroids.StateMachine.States
{
    public abstract class StateMachine : IStateMachine
    {
        protected Dictionary<Type, IExitableState> _registeredStates;
        protected ITickable _currentTickableState;
        protected IExitableState _currentState;

        public void Enter<TState>() where TState : class, IState
        {
            TState newState = ChangeState<TState>();
            newState.Enter();
        }

        public void Enter<TState, TArg1>(TArg1 arg1) where TState : class, IStateWithArguments<TArg1>
        {
            TState newState = ChangeState<TState>();
            newState.Enter(arg1);
        }

        public void Enter<TState, TArg1, TArg2>(TArg1 arg1, TArg2 arg2) where TState : class, IStateWithArguments<TArg1, TArg2>
        {
            TState newState = ChangeState<TState>();
            newState.Enter(arg1, arg2);
        }

        public void Enter<TState, TArg1, TArg2, TArg3>(TArg1 arg1, TArg2 arg2, TArg3 arg3) where TState : class, IStateWithArguments<TArg1, TArg2, TArg3>
        {
            TState newState = ChangeState<TState>();
            newState.Enter(arg1, arg2, arg3);
        }

        protected void RegisterState<TState>(TState state) where TState : IExitableState =>
            _registeredStates.Add(typeof(TState), state);

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();

            TState state = GetState<TState>();
            _currentState = state;
            _currentTickableState = _currentState as ITickable;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _registeredStates[typeof(TState)] as TState;
    }
}