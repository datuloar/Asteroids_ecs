using Asteroids.Core.Ecs.Components;
using Leopotam.EcsLite;

namespace Asteroids.Core.Ecs.Systems
{
    public sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter _filter;
        private readonly EcsPool<MovementComponent> _movementPool;
        private readonly EcsPool<TransformComponent> _transformPool;

        public MovementSystem(EcsWorld world)
        {
            _world = world;

            _filter = _world
                .Filter<MovementComponent>()
                .Inc<MovementSpeedComponent>()
                .Inc<TransformComponent>()
                .End();

            _movementPool = _world.GetPool<MovementComponent>();
            _transformPool = _world.GetPool<TransformComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                ref var movement = ref _movementPool.Get(entity);
                ref var transform = ref _transformPool.Get(entity).Value;           
            }
        }
    }
}

