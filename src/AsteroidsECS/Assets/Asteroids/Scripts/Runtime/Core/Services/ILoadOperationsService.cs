using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Asteroids.Core.Services
{
    public interface ILoadOperationsService
    {
        event Action<ILoadingOperation> OperationChanged;
        event Action<float> ProgressChanged;

        UniTask LoadAsync(Queue<LazyLoadingOperation> operations);
    }
}