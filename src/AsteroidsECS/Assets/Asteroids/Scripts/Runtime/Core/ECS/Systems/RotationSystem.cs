using Asteroids.Core.Ecs.Components;
using Leopotam.EcsLite;

namespace Asteroids.Core.Ecs.Systems
{
    public sealed class RotationSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter _filter;
        private readonly EcsPool<RotationComponent> _rotationPool;
        private readonly EcsPool<TransformComponent> _transformPool;

        public RotationSystem(EcsWorld world)
        {
            _world = world;

            _filter = _world
                .Filter<MovementComponent>()
                .Inc<MovementSpeedComponent>()
                .Inc<TransformComponent>()
                .End();

            _rotationPool = _world.GetPool<RotationComponent>();
            _transformPool = _world.GetPool<TransformComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                ref var rotation = ref _rotationPool.Get(entity);
                ref var transform = ref _transformPool.Get(entity).Value;
            }
        }
    }
}

