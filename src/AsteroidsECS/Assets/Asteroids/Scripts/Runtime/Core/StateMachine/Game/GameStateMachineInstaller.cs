using UnityEngine;
using Zenject;

namespace Asteroids.StateMachine.States
{
    public class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<IGameStateMachine, BootstrapState, BootstrapStateFactory>();
            Container.BindFactory<IGameStateMachine, SceneLoopState, SceneLoopStateFactory>();
            Container.BindFactory<IGameStateMachine, LoadSceneState, LoadSceneStateFactory>();

            Container.Bind(typeof(IGameStateMachine), typeof(ITickable)).To<GameStateMachine>().AsSingle();
        }
    }

    public class BootstrapStateFactory : PlaceholderFactory<IGameStateMachine, BootstrapState> { }

    public class SceneLoopStateFactory : PlaceholderFactory<IGameStateMachine, SceneLoopState> { }

    public class LoadSceneStateFactory : PlaceholderFactory<IGameStateMachine, LoadSceneState> { }
}