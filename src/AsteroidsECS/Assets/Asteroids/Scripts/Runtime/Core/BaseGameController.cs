using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace Asteroids.Core.Game
{
    public abstract class BaseGameController : MonoBehaviour
    {
        public abstract event Action Completed;
        public abstract event Action Paused;

        public virtual UniTask PreInitialize() => UniTask.CompletedTask;

        public virtual UniTask Initialize() => UniTask.CompletedTask;

        public virtual void Tick() { }

        public virtual void CleanUp() { }
    }
}
