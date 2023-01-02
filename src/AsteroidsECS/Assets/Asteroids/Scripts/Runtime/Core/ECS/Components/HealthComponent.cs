using System;

namespace Asteroids.Core.Ecs.Components
{
    [Serializable]
    public struct HealthComponent
    {
        public float Current;
        public float Max;
    }
}

