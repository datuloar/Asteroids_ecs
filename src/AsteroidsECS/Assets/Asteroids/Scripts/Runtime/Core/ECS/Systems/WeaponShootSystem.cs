using Asteroids.Core.Ecs.Components;
using Asteroids.Core.Ecs.Requests;
using Asteroids.Core.Services.Factory;
using Leopotam.EcsLite;

namespace Asteroids.Core.Ecs.Systems
{
    public sealed class WeaponShootSystem : IEcsRunSystem
    {
        private readonly IProjectileFactory _projectileFactory;
        private readonly EcsWorld _world;
        private readonly EcsFilter _filter;
        private readonly EcsPool<ShootRequest> _shootRequestPool;
        private readonly EcsPool<WeaponsHolderComponent> _weaponsHolderPool;
        private readonly EcsPool<WeaponComponent> _weaponPool;
        private readonly EcsPool<TransformComponent> _transformPool;
        private readonly EcsPool<CooldownComponent> _cooldownPool;

        public WeaponShootSystem(EcsWorld world, IProjectileFactory projectileFactory)
        {
            _world = world;
            _projectileFactory = projectileFactory;

            _filter = _world.Filter<ShootRequest>().End();

            _shootRequestPool = _world.GetPool<ShootRequest>();
            _weaponsHolderPool = _world.GetPool<WeaponsHolderComponent>();
            _cooldownPool = _world.GetPool<CooldownComponent>();
            _weaponPool = _world.GetPool<WeaponComponent>();
            _transformPool = _world.GetPool<TransformComponent>();
        }

        public async void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                var request = _shootRequestPool.Get(entity);

                if (!request.Sender.Unpack(_world, out int senderEntity))
                    continue;

                var weaponsHolder = _weaponsHolderPool.Get(senderEntity);

                foreach (var weaponPacked in weaponsHolder.Weapons)
                {
                    if (!weaponPacked.Unpack(_world, out int weaponEntity))
                        continue;

                    if (!_cooldownPool.Has(weaponEntity))
                        continue;

                    var weapon = _weaponPool.Get(weaponEntity);
                    var config = weapon.Config;
                    var transform = _transformPool.Get(senderEntity).Value;

                    _projectileFactory.CreateAsync(_world, config.ProjectileType, transform.position, transform.rotation.eulerAngles);
                }
            }
        }
    }
}

