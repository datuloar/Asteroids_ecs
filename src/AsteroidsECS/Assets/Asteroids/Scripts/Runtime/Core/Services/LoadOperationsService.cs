using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Asteroids.Core.Services
{
    public class LoadOperationsService : ILoadOperationsService
    {
        public event Action<ILoadingOperation> OperationChanged;
        public event Action<float> ProgressChanged;

        public async UniTask LoadAsync(Queue<LazyLoadingOperation> operations)
        {
            foreach (var lazyOperation in operations)
            {
                ILoadingOperation loadingOperation = lazyOperation.Value;
                OperationChanged?.Invoke(loadingOperation);

                while (!loadingOperation.IsComplete)
                {
                    ProgressChanged?.Invoke(loadingOperation.Progress);
                    await loadingOperation.LoadAsync();
                }
            }
        }
    }
}