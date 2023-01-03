using Asteroids.Core.Scene;

namespace Asteroids.StateMachine.States
{
    public class LoadSceneState : IStateWithArguments<SceneData>
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadSceneState(
            IGameStateMachine gameStateMachine,
            ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public async void Enter(SceneData sceneData)
        {
            BaseSceneView baseSceneView = await _sceneLoader.LoadSceneAsync(sceneData.Name, sceneData.LoadMode);
            await baseSceneView.PreInitialize();
            await baseSceneView.Initialize();

            _gameStateMachine.Enter<SceneLoopState, BaseSceneView>(baseSceneView);
        }

        public void Exit()
        {
            
        }
    }
}