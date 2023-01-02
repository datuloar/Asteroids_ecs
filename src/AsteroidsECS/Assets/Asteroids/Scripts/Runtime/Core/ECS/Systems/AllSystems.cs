using Asteroids.Core.Ecs.Systems;

namespace Asteroids.Core.Ecs
{
    public sealed class AllSystems : Feature
    {
        public AllSystems(GameContext context) : base(context)
        {
            Add(new GameplaySystems(context));
            Add(new CleanUpSystems(context));
        }
    }
}

