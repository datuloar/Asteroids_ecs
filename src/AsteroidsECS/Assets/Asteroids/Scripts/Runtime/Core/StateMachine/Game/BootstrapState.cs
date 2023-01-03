﻿using Asteroids.Core.Scene;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Asteroids.StateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public BootstrapState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public async void Enter()
        {
            await InitializeExternalServices();

            _gameStateMachine.Enter<LoadSceneState, SceneData>(new SceneData
            {
                Name = "Level ...",
                LoadMode = UnityEngine.SceneManagement.LoadSceneMode.Additive
            });
        }

        public void Exit()
        {
            
        }

        private async UniTask InitializeExternalServices()
        {
            // Steam API
            // Epic API
            // etc

            await UniTask.CompletedTask;
        }
    }
}