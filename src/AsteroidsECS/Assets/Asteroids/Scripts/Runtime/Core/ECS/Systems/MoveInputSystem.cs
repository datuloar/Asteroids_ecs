using Asteroids.Core.Ecs.Components;
using Asteroids.Core.Ecs.Tags;
using Asteroids.Core.Services;
using Leopotam.EcsLite;

namespace Asteroids.Core.Ecs.Systems
{
    public sealed class MoveInputSystem : IEcsRunSystem
    {
        private readonly IInputService _inputService;
        private readonly EcsWorld _world;
        private readonly EcsFilter _playerFilter;
        private readonly EcsPool<MovementComponent> _movementPool;

        public MoveInputSystem(EcsWorld world, IInputService inputService)
        {
            _world = world;
            _inputService = inputService;

            _playerFilter = _world
                .Filter<PlayerTag>()
                .Inc<MovementComponent>()
                .End();

            _movementPool = _world.GetPool<MovementComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var playerEntity in _playerFilter)
            {
                ref var movement = ref _movementPool.Get(playerEntity);
                movement.Direction = _inputService.MovementDirection.normalized;
            }
        }
    }
}

