using Asteroids.StateMachine.States;

namespace Asteroids.StateMachine.States
{
    public interface IStateWithArguments<TArg1> : IExitableState
    {
        void Enter(TArg1 arg1);
    }

    public interface IStateWithArguments<TArg1, TArg2> : IExitableState
    {
        void Enter(TArg1 arg1, TArg2 arg2);
    }

    public interface IStateWithArguments<TArg1, TArg2, TArg3> : IExitableState
    {
        void Enter(TArg1 arg1, TArg2 arg2, TArg3 arg3);
    }
}