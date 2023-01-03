using Asteroids.Core.Scene;
using UnityEngine;
using Zenject;

namespace Asteroids.StateMachine.States
{
    public class SceneLoopState : IStateWithArguments<BaseSceneView>, ITickable
    {
        private readonly IGameStateMachine _gameStateMachine;

        private BaseSceneView _baseSceneView;

        public SceneLoopState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter(BaseSceneView baseSceneView)
        {
            _baseSceneView = baseSceneView;
        }

        public void Exit()
        {
            _baseSceneView.CleanUp();
        }

        public void Tick()
        {
            _baseSceneView.Tick();
        }
    }
}