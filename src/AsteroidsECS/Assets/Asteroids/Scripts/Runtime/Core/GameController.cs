using Asteroids.Core.Ecs;
using Cysharp.Threading.Tasks;
using System;
using Zenject;

namespace Asteroids.Core.Game
{
    public class GameController : BaseGameController
    {
        private IECSRunner _ecsRunner;

        public override event Action Completed;
        public override event Action Paused;

        [Inject]
        public void Construct(IECSRunner ecsRunner)
        {
            _ecsRunner = ecsRunner;
        }

        public async override UniTask Initialize()
        {
            _ecsRunner.Initialize();
            await UniTask.CompletedTask;
        }

        public override void Tick()
        {
            _ecsRunner.Tick();
        }

        public override void CleanUp()
        {
            _ecsRunner.CleanUp();
        }
    }
}