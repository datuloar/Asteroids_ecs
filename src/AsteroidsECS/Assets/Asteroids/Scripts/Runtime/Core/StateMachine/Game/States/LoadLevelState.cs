using Asteroids.Core.Game;
using Asteroids.Core.Scene;
using System;

namespace Asteroids.StateMachine.States
{
    public class LoadLevelState : IStateWithArguments<LoadLevelData>
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadLevelState(
            IGameStateMachine gameStateMachine,
            ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public async void Enter(LoadLevelData sceneData)
        {
            await _sceneLoader.LoadSceneAsync(sceneData.Name, sceneData.LoadMode);

            var baseGameController = GetGameControllerFromLoadedScene();
            await baseGameController.PreInitialize();
            await baseGameController.Initialize();

            _gameStateMachine.Enter<GameLoopState, BaseGameController>(baseGameController);
        }

        public void Exit()
        {
            
        }

        private BaseGameController GetGameControllerFromLoadedScene()
        {
            var baseGameController = UnityEngine.Object.FindObjectOfType<BaseGameController>();

            if (baseGameController == null)
                throw new Exception($"Base game controller doesn't found");

            return baseGameController;
        }
    }
}