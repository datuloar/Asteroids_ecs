using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Cysharp.Threading.Tasks;

namespace Asteroids.Core.Services.Assets
{
    public sealed class AddressablesAssetsProvider : IAssetsProvider
    {
        private readonly Dictionary<string, AsyncOperationHandle> _completedHandleCache = new();

        public void Initialize() => Addressables.InitializeAsync();

        public async UniTask<TAsset> LoadAsync<TAsset>(string address) where TAsset : UnityEngine.Object
        {
            if(_completedHandleCache.TryGetValue(address, out var cacheHandle))
                return cacheHandle.Result as TAsset;
            
            return await LoadWithCacheOnComplete<TAsset>(address);
        }

        public void CleanUp()
        {
            foreach (var pair in _completedHandleCache)
                Addressables.Release(pair.Value);

            _completedHandleCache.Clear();
        }

        private async UniTask<TResource> LoadWithCacheOnComplete<TResource>(string address)
        {
            var handle = Addressables.LoadAssetAsync<TResource>(address);

            handle.Completed += operationHandle =>
            {
                _completedHandleCache[address] = operationHandle;
            };

            return await handle.Task;
        }
    }   
}

