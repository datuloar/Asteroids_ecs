using Asteroids.StateMachine.States;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        ServicesInstaller.Install(Container);
        GameStateMachineInstaller.Install(Container);
    }
}
