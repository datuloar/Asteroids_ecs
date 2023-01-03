using Asteroids.StateMachine.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Asteroids.Core
{
    public class GameBootstrap : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Start()
        {
            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}