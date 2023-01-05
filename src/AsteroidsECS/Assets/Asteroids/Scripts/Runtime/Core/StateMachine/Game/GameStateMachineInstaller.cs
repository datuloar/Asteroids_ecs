using UnityEngine;
using Zenject;

namespace Asteroids.StateMachine.States
{
    public class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<IGameStateMachine, LoadGameState, BootstrapStateFactory>();
            Container.BindFactory<IGameStateMachine, GameLoopState, GameLoopStateFactory>();
            Container.BindFactory<IGameStateMachine, LoadLevelState, LoadLevelStateFactory>();

            Container.Bind(typeof(IGameStateMachine), typeof(ITickable)).To<GameStateMachine>().AsSingle();
        }
    }

    public class BootstrapStateFactory : PlaceholderFactory<IGameStateMachine, LoadGameState> { }

    public class GameLoopStateFactory : PlaceholderFactory<IGameStateMachine, GameLoopState> { }

    public class LoadLevelStateFactory : PlaceholderFactory<IGameStateMachine, LoadLevelState> { }
}