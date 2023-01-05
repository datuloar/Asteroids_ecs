using Cysharp.Threading.Tasks;

namespace Asteroids.Core.Services
{
    public interface ILoadingOperation
    {
        string Description { get; }
        float Progress { get; }
        bool IsComplete { get; }

        UniTask LoadAsync();
    }
}