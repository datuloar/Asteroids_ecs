using Asteroids.Core.Scene;
using Asteroids.Core.Services;
using Asteroids.UI;
using UnityEngine.SceneManagement;

namespace Asteroids.StateMachine.States
{
    public class LoadGameState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IGameLoadingWindow _gameLoadingWindow;
        private readonly ILoadOperationsService _loadOperationsService;

        public LoadGameState(
            IGameStateMachine gameStateMachine,
            IGameLoadingWindow gameLoadingWindow,
            ILoadOperationsService loadOperationsService)
        {
            _gameStateMachine = gameStateMachine;
            _gameLoadingWindow = gameLoadingWindow;
            _loadOperationsService = loadOperationsService;
        }

        public async void Enter()
        {
            _loadOperationsService.OperationChanged += OnLoadOperationChanged;
            _loadOperationsService.ProgressChanged += OnLoadOperationProgressChanged;

            await _loadOperationsService.LoadAsync(null);

            _gameStateMachine.Enter<LoadLevelState, LoadLevelData>(
                new LoadLevelData("Level 1", LoadSceneMode.Additive));
        }

        public void Exit()
        {
            _loadOperationsService.OperationChanged -= OnLoadOperationChanged;
            _loadOperationsService.ProgressChanged -= OnLoadOperationProgressChanged;
        }

        private void OnLoadOperationProgressChanged(float value)
        {
            _gameLoadingWindow.FillProgress(value);
        }

        private void OnLoadOperationChanged(ILoadingOperation loadingOperation)
        {
            _gameLoadingWindow.SetOperationInfo(loadingOperation.Description);
            _gameLoadingWindow.ResetFill();
        }
    }
}