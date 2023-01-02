namespace Asteroids.Core.Ecs.Systems
{
    public sealed class CleanUpSystems : Feature
    {
        public CleanUpSystems(GameContext context) : base(context)
        {
            Add(new DestroySystem(context.World));
        }
    }
}

