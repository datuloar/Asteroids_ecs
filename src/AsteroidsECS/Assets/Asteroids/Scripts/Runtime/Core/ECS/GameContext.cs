using Asteroids.Core.Services;
using Asteroids.Core.Services.Factory;
using Leopotam.EcsLite;
using Zenject;

namespace Asteroids.Core.Ecs
{
    public sealed class GameContext
    {
        public GameContext(
            EcsWorld world,
            EcsSystems systems,
            DiContainer container,
            IGameFactory gameFactory,
            IInputService inputService)
        {
            World = world;
            EcsSystems = systems;
            InputService = inputService;
            DiContainer = container;
            GameFactory = gameFactory;
        }

        public EcsWorld World { get; }
        public EcsSystems EcsSystems { get; }
        public DiContainer DiContainer { get; }
        public IInputService InputService { get; }
        public IGameFactory GameFactory { get; }
    }
}

