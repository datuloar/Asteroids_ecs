using Asteroids.Core.Ecs.Tags;
using Leopotam.EcsLite;

namespace Asteroids.Core.Ecs.Systems
{
    public sealed class DestroySystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter _filter;

        public DestroySystem(EcsWorld world)
        {
            _world = world;

            _filter = _world.Filter<DestroyTag>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
                _world.DelEntity(entity);           
        }
    }
}

