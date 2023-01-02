namespace Asteroids.Core.Ecs
{
    public interface IECSRunner
    {
        void CleanUp();
        void Initialize();
        void Tick();
    }
}

