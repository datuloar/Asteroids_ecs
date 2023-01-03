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

            _baseGameController.Completed += OnGameCompleted;
            _baseGameController.Completed += OnGamePaused;
        }

        public void Exit()
        {
            _baseGameController.CleanUp();

            _baseGameController.Completed -= OnGameCompleted;
            _baseGameController.Completed -= OnGamePaused;
        }

        public void Tick()
        {
            _baseGameController.Tick();
        }

        private void OnGamePaused()
        {
            throw new NotImplementedException();
        }

        private void OnGameCompleted()
        {
            throw new NotImplementedException();
        }
    }
}