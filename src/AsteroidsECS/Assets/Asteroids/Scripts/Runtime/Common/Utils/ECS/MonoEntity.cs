using Leopotam.EcsLite;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Ecs.Utils
{
    public class MonoEntity : MonoBehaviour
    {
        [SerializeField] private ConvertType _convertType = ConvertType.CreateAndDestroyProviders;
        [SerializeField] private List<MonoProvider> _providers;

        public EcsPackedEntity Entity { get; private set; }
        public bool IsInitialized { get; private set; }

        public void Initialize(EcsWorld world) =>
            Initialize(world, world.NewEntity());

        public void Initialize(EcsWorld world, int entity)
        {
            if (IsInitialized)
                return;

            Entity = world.PackEntity(entity);

            foreach (var provider in _providers)
            {
                provider.Initialize(world, entity);

                if (_convertType == ConvertType.CreateAndDestroyProviders)
                    Destroy(provider);
            }

            _providers.Clear();
            IsInitialized = true;
        }
    }
}

