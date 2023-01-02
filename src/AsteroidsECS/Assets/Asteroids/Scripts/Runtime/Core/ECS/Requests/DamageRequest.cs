using Leopotam.EcsLite;

namespace Asteroids.Core.Ecs.Requests
{
    public struct DamageRequest
    {
        public EcsPackedEntity Receiver;
        public int Value;
    }
}

