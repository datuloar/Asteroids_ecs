namespace Asteroids.Core.Ecs.Systems
{
    public sealed class SpawnSystems : Feature
    {
        public SpawnSystems(GameContext context) : base(context)
        {
            Add(new SpawnPlayerSystem(context.World, context.GameFactory.ShipFactory));
        }
    }
}

