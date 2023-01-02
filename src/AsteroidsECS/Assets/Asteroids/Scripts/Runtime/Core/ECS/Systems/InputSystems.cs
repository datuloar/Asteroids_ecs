using Asteroids.Core.Ecs.Events;

namespace Asteroids.Core.Ecs.Systems
{
    public sealed class InputSystems : Feature
    {
        public InputSystems(GameContext context) : base(context)
        {
            DelHere<FireButtonDownEvent>();
            DelHere<LaserButtonDownEvent>();

            Add(new MoveInputSystem(context.World, context.InputService));
            Add(new AttackInputSystem(context.World, context.InputService));
            Add(new RotationInputSystem(context.World, context.InputService));
        }
    }
}

