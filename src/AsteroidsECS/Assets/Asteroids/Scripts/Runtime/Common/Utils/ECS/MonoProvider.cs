using Leopotam.EcsLite;
using UnityEngine;


namespace Common.Ecs.Utils
{
    [RequireComponent(typeof(MonoEntity))]
    public abstract class MonoProvider<TEntity> : MonoProvider where TEntity : struct
    {
        [SerializeField] protected TEntity _value;

        public override void Initialize(EcsWorld world, int entity) =>
            world.AddComponent(entity, _value);
    }
}

