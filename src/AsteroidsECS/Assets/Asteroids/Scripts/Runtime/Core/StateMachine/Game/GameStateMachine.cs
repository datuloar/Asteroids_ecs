using Zenject;

namespace Asteroids.StateMachine.States
{
    public class GameStateMachine : StateMachine, IGameStateMachine, ITickable
    {       
        public GameStateMachine(
            BootstrapStateFactory bootstrapStateFactory,
            LoadLevelStateFactory loadLevelStateFactory,
            GameLoopStateFactory gameLoopStateFactory)
        {
            _registeredStates = new ();
            
            RegisterState(bootstrapStateFactory.Create(this));
            RegisterState(loadLevelStateFactory.Create(this));
            RegisterState(gameLoopStateFactory.Create(this));
        }

        public void Tick()
        {
            _currentTickableState?.Tick();
        }      
    }
}