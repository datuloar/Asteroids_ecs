using Asteroids.Core.Ecs;
using Cysharp.Threading.Tasks;
using System;
using System.Diagnostics;
using Zenject;

namespace Asteroids.Core.Game
{
    public class GameController : BaseGameController
    {
        private IECSRunner _ecsRunner;

        [Inject]
        public void Construct(IECSRunner ecsRunner)
        {
            _ecsRunner = ecsRunner;
            print("construct");
        }

        public async override UniTask Initialize()
        {
            _ecsRunner.Initialize(); 
            print("init");

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