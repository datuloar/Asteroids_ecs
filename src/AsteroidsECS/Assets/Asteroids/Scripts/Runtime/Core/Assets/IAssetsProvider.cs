using Cysharp.Threading.Tasks;

namespace Asteroids.Core.Services.Assets
{
    public interface IAssetsProvider
    {
        void Initialize();
        UniTask<TAsset> LoadAsync<TAsset>(string address) where TAsset : UnityEngine.Object;
        void CleanUp();
    }
}

