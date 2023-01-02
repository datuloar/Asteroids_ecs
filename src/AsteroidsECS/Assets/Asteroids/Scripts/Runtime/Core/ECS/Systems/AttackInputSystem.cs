using Asteroids.Core.Ecs.Events;
using Asteroids.Core.Services;
using Leopotam.EcsLite;

namespace Asteroids.Core.Ecs.Systems
{
    public sealed class AttackInputSystem : IEcsRunSystem
    {
        private readonly IInputService _inputService;
        private readonly EcsWorld _world;

        public AttackInputSystem(EcsWorld world, IInputService inputService)
        {
            _world = world;
            _inputService = inputService;
        }

        public void Run(IEcsSystems systems)
        {
            if (_inputService.IsFireButtonDown())
                _world.AddNewEntityWith<FireButtonDownEvent>();

            if (_inputService.IsLaserButtonDown())
                _world.AddNewEntityWith<LaserButtonDownEvent>();
        }
    }
}

