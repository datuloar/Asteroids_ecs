using Leopotam.EcsLite;

namespace Asteroids.Core.Ecs.Requests
{
    public struct ShootRequest
    {
        public EcsPackedEntity Sender;
        public int WeaponIndex;
        public int IgnoreCooldown;
    }
}

