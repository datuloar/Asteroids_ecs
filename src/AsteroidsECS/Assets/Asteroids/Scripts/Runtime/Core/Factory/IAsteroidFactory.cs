using Leopotam.EcsLite;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Asteroids.Core.Configs;

namespace Asteroids.Core.Services.Factory
{
    public interface IAsteroidFactory
    {
        UniTask<int> CreateAsync(EcsWorld world, AsteroidType type, Vector3 position, Vector3 rotation);
    }
}

