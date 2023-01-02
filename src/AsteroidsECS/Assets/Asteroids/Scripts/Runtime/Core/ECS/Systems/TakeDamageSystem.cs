using Asteroids.Core.Ecs.Components;
using Asteroids.Core.Ecs.Requests;
using Leopotam.EcsLite;

namespace Asteroids.Core.Ecs.Systems
{
    public sealed class TakeDamageSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter _filter;
        private readonly EcsPool<DamageRequest> _requestPool;
        private readonly EcsPool<HealthComponent> _healthPool;

        public TakeDamageSystem(EcsWorld world)
        {
            _world = world;

            _filter = _world.Filter<DamageRequest>().End();

            _requestPool = _world.GetPool<DamageRequest>();
            _healthPool = _world.GetPool<HealthComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                ref var request = ref _requestPool.Get(entity);

                if (!request.Receiver.Unpack(_world, out int receiverEntity))
                    continue;

                if (!_healthPool.Has(receiverEntity))
                    continue;

                ref var health = ref _healthPool.Get(receiverEntity);
                health.Current -= request.Value;
            }
        }
    }
}

