using Leopotam.EcsLite;
using UnityEngine;


namespace Common.Ecs.Utils
{
    public abstract class MonoProvider : MonoBehaviour
    {
        public abstract void Initialize(EcsWorld world, int entity);
    }
}

