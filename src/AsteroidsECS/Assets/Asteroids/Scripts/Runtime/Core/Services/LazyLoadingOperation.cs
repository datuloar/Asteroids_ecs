using System;

namespace Asteroids.Core.Services
{
    public sealed class LazyLoadingOperation
    {
        private readonly Lazy<ILoadingOperation> _loadingOperations;

        public LazyLoadingOperation(Func<ILoadingOperation> func)
        {
            _loadingOperations = new ();
        }

        public ILoadingOperation Value => _loadingOperations.Value;

        public static implicit operator LazyLoadingOperation(Func<ILoadingOperation> func)
        {
            return new LazyLoadingOperation(func);
        }
    }
}