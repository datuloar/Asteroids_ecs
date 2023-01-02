using Asteroids.Core.Services.Assets;
using Common.Ecs.Utils;
using Leopotam.EcsLite;
using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Asteroids.Core.Configs;

namespace Asteroids.Core.Services.Factory
{
    public sealed class ShipFactory : IShipFactory
    {
        private readonly IAssetsProvider _assetsProvider;
        private readonly IConfigProvider _configProvider;

        public ShipFactory(IAssetsProvider assetsProvider, IConfigProvider configProvider)
        {
            _assetsProvider = assetsProvider;
            _configProvider = configProvider;
        }

        public async UniTask<int> CreateAsync(EcsWorld world, ShipType type, Vector3 position, Vector3 rotation)
        {
            switch (type)
            {
                case ShipType.Сhaser:
                    return await CreateChaser(world, position, rotation);
                case ShipType.Ufo:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentException($"Missing ship type {type}");
            }
        }

        private async UniTask<int> CreateChaser(EcsWorld world, Vector3 position, Vector3 rotation)
        {
            ShipConfig config = _configProvider.GetShipConfig(ShipType.Сhaser);
            GameObject prefab = await _assetsProvider.LoadAsync<GameObject>(config.PrefabReference.AssetGUID);
            GameObject instance = GameObject.Instantiate(prefab, position, Quaternion.Euler(rotation));

            int entity = InitializeMonoEntity(world, instance);

            return entity;
        }

        private int InitializeMonoEntity(EcsWorld world, GameObject instance)
        {
            if (!instance.TryGetComponent(out MonoEntity monoEntity))
                throw new NullReferenceException("Missing mono entity on component");

            monoEntity.Initialize(world);

            if (!monoEntity.Entity.Unpack(world, out int entity))
                throw new InvalidOperationException("Initialize failed!");

            return entity;
        }
    }
}

