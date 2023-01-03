using Asteroids.Core.Game;
using System;
using Zenject;

namespace Asteroids.StateMachine.States
{
    public class GameLoopState : IStateWithArguments<BaseGameController>, ITickable
    {
        private readonly IGameStateMachine _gameStateMachine;

        private BaseGameController _baseGameController;

        public GameLoopState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter(BaseGameController baseGameController)
        {
            _baseGameController = baseGameController;
        }

        public void Exit()
        {
            _baseGameController.CleanUp();
        }

        public void Tick()
        {
            _baseGameController.Tick();
        }
    }
}