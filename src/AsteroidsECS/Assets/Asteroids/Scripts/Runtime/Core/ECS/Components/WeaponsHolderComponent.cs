using Leopotam.EcsLite;
using System.Collections.Generic;

namespace Asteroids.Core.Ecs.Components
{
    public struct WeaponsHolderComponent
    {
        private List<EcsPackedEntity> _weapons;
        private Dictionary<int, EcsPackedEntity> _indexOfWeapons;

        public IReadOnlyList<EcsPackedEntity> Weapons => _weapons;
        public Dictionary<int, EcsPackedEntity> IndexOfWeapons => _indexOfWeapons;

        public void Init(int size)
        {
            _weapons = new(size);
            _indexOfWeapons = new(size);
        }

        public void AddWeapon(EcsWorld world, EcsPackedEntity weapon)
        {
            if (!weapon.Unpack(world, out int weaponEntity))
                return;

            var weaponIndex = world
                .GetPool<WeaponComponent>()
                .Get(weaponEntity)
                .Config
                .Id;

            _indexOfWeapons.Add(weaponIndex, weapon);
            _weapons.Add(weapon);
        }

        public void RemoveWeapon(EcsWorld world, EcsPackedEntity weapon)
        {
            if (!weapon.Unpack(world, out int weaponEntity))
                return;

            var weaponIndex = world
                .GetPool<WeaponComponent>()
                .Get(weaponEntity)
                .Config
                .Id;

            _weapons.Remove(weapon);
            _indexOfWeapons.Remove(weaponIndex);
        }
    }
}

