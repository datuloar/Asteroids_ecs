using Asteroids.Core.Ecs.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Asteroids.Core.Ecs.Systems
{
    public class CooldownSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter _filter;
        private readonly EcsPool<CooldownComponent> _cooldownPool;

        public CooldownSystem(EcsWorld world)
        {
            _world = world;

            _filter = _world.Filter<CooldownComponent>().End();

            _cooldownPool = _world.GetPool<CooldownComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                ref var cooldown = ref _cooldownPool.Get(entity).Value;

                cooldown -= Time.deltaTime;

                if (cooldown <= 0)
                    _cooldownPool.Del(entity);
            }
        }
    }
}

