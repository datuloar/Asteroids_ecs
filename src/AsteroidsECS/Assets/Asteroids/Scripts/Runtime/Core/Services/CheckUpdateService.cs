using Cysharp.Threading.Tasks;

namespace Asteroids.Core.Services
{
    public class CheckUpdateService : ILoadingOperation
    {
        public string Description => "Check Update";

        public float Progress { get; private set; }

        public bool IsComplete => Progress == 1f;

        public UniTask LoadAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}