using UnityEngine;
using Zenject;

namespace Asteroids.StateMachine.States
{
    public class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<IGameStateMachine, BootstrapState, BootstrapStateFactory>();
            Container.BindFactory<IGameStateMachine, GameLoopState, GameLoopStateFactory>();
            Container.BindFactory<IGameStateMachine, LoadLevelState, LoadLevelStateFactory>();

            Container.Bind(typeof(IGameStateMachine), typeof(ITickable)).To<GameStateMachine>().AsSingle();
        }
    }

    public class BootstrapStateFactory : PlaceholderFactory<IGameStateMachine, BootstrapState> { }

    public class GameLoopStateFactory : PlaceholderFactory<IGameStateMachine, GameLoopState> { }

    public class LoadLevelStateFactory : PlaceholderFactory<IGameStateMachine, LoadLevelState> { }
}