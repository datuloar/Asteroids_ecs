using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Asteroids.Core.Game
{
    public abstract class BaseGameController : MonoBehaviour
    {
        public virtual UniTask PreInitialize() => UniTask.CompletedTask;

        public virtual UniTask Initialize() => UniTask.CompletedTask;

        public virtual void Tick() { }

        public virtual void CleanUp() { }
    }
}
