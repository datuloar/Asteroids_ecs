using Asteroids.StateMachine.States;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        GameStateMachineInstaller.Install(Container);
    }
}
