using Asteroids.Core.Services.Assets;
using Leopotam.EcsLite;
using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Asteroids.Core.Configs;

namespace Asteroids.Core.Services.Factory
{
    public sealed class AsteroidFactory : IAsteroidFactory
    {
        private const string AsteroidsPath = "Assets/Asteroids/Prefabs/ChaserShip.prefab";

        private readonly IAssetsProvider _assetsProvider;
        private readonly IConfigProvider _configProvider;

        public AsteroidFactory(IAssetsProvider assetsProvider, IConfigProvider configProvider)
        {
            _assetsProvider = assetsProvider;
            _configProvider = configProvider;
        }

        public UniTask<int> CreateAsync(EcsWorld world, AsteroidType type, Vector3 position, Vector3 rotation)
        {
            throw new NotImplementedException();
        }
    } 
}

