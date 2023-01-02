namespace Asteroids.Core.Services.Factory
{
    public interface IGameFactory
    {
        IAsteroidFactory AsteroidFactory { get; }
        IShipFactory ShipFactory { get; }
    }
}

