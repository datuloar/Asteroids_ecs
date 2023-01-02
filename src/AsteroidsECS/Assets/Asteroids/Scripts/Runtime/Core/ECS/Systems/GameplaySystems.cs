using Asteroids.Core.Ecs.Requests;

namespace Asteroids.Core.Ecs.Systems
{
    public sealed class GameplaySystems : Feature
    {
        public GameplaySystems(GameContext context) : base(context)
        {
            Add(new InputSystems(context));
            Add(new SpawnSystems(context));
            Add(new MovementSystem(context.World));
            Add(new RotationSystem(context.World));
            Add(new TakeDamageSystem(context.World));
            Add(new CooldownSystem(context.World));

            DelHere<DamageRequest>();
        }
    }
}

