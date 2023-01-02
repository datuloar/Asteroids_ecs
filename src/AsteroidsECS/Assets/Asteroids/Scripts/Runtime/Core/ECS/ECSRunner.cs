using Asteroids.Core.Services;
using Asteroids.Core.Services.Factory;
using Leopotam.EcsLite;
using Zenject;

namespace Asteroids.Core.Ecs
{
    public class ECSRunner : IECSRunner
    {
        private readonly EcsWorld _world;
        private readonly AllSystems _allSystems;

        public ECSRunner(IInputService inputService, IGameFactory gameFactory, DiContainer container)
        {
            _world = new EcsWorld();
            var systems = new EcsSystems(_world);
            var context = new GameContext(_world, systems, container, gameFactory, inputService);
            _allSystems = new AllSystems(context);
        }

        public void Initialize() => _allSystems.Init();

        public void Tick() => _allSystems.Run();

        public void CleanUp()
        {
            _allSystems.Destroy();
            _world.Destroy();
        }
    }
}

