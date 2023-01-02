using Asteroids.Core.Ecs.Systems;
using Leopotam.EcsLite.ExtendedSystems;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Asteroids.Core.Ecs
{
    public partial class GameRoot : MonoBehaviour
    {
        private IECSRunner _ecsRunner;

        [Inject]
        public void Construct(IECSRunner ecsRunner)
        {
            _ecsRunner = ecsRunner;
        }

        private partial void NetworkInit();

        private void Start()
        {
            NetworkInit();
            _ecsRunner.Initialize();
        }

        private void Update()
        {
            _ecsRunner.Tick();
        }

        private void OnDestroy()
        {
            _ecsRunner.CleanUp();
        }
    }

    //Server
    public partial class GameRoot
    {
        private partial void NetworkInit()
        {

        }
    }
}


