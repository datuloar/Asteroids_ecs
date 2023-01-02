using Asteroids.Core.Ecs.Tags;
using Asteroids.Core.Services.Factory;
using Leopotam.EcsLite;
using UnityEngine;
using Asteroids.Core.Configs;

namespace Asteroids.Core.Ecs.Systems
{
    public sealed class SpawnPlayerSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;
        private readonly IShipFactory _shipFactory;

        public SpawnPlayerSystem(EcsWorld world, IShipFactory shipFactory)
        {
            _world = world;
            _shipFactory = shipFactory;
        }

        public async void Init(IEcsSystems systems)
        {
            var entity = await _shipFactory.CreateAsync(_world, ShipType.Сhaser, Vector3.zero, Vector3.zero);
            _world.AddComponent<PlayerTag>(entity);
        }
    }
}

