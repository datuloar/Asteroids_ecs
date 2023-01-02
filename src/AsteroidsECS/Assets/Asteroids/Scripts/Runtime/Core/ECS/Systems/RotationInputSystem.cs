using Asteroids.Core.Ecs.Components;
using Asteroids.Core.Ecs.Tags;
using Asteroids.Core.Services;
using Leopotam.EcsLite;

namespace Asteroids.Core.Ecs.Systems
{
    public sealed class RotationInputSystem : IEcsRunSystem
    {
        private readonly IInputService _inputService;
        private readonly EcsWorld _world;
        private readonly EcsFilter _playerFilter;
        private readonly EcsPool<RotationComponent> _rotationPool;

        public RotationInputSystem(EcsWorld world, IInputService inputService)
        {
            _world = world;
            _inputService = inputService;

            _playerFilter = _world
                .Filter<PlayerTag>()
                .Inc<RotationComponent>()
                .End();

            _rotationPool = _world.GetPool<RotationComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var playerEntity in _playerFilter)
            {
                ref var rotation = ref _rotationPool.Get(playerEntity);
                rotation.Direction = _inputService.WorldMousePosition.normalized;
            }
        }
    }
}

