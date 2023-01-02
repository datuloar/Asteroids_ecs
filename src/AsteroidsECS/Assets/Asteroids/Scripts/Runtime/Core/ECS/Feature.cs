using Leopotam.EcsLite;
using Leopotam.EcsLite.ExtendedSystems;

namespace Asteroids.Core.Ecs
{
    public abstract class Feature : IEcsSystem
    {
        private readonly GameContext _gameContext;

        public Feature(GameContext context)
        {
            _gameContext = context;
        }

        protected void Add(IEcsSystem system)
        {
            _gameContext.EcsSystems.Add(system);
        }

        protected void DelHere<T>() where T : struct
        {
            _gameContext.EcsSystems.DelHere<T>();
        }

        public void Init()
        {
            _gameContext.EcsSystems.Init();
        }

        public void Run()
        {
            _gameContext.EcsSystems?.Run();
        }

        public void Destroy()
        {
            _gameContext.EcsSystems.Destroy();
        }
    }
}

