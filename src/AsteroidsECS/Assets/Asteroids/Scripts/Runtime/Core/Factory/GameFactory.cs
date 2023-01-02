using Asteroids.Core.Services.Assets;
using Asteroids.Core.Configs;

namespace Asteroids.Core.Services.Factory
{
    public sealed class GameFactory : IGameFactory
    {
        public GameFactory(IConfigProvider configProvider, IAssetsProvider assetsProvider)
        {
            assetsProvider.Initialize();

            ShipFactory = new ShipFactory(assetsProvider, configProvider);
            AsteroidFactory = new AsteroidFactory(assetsProvider, configProvider);
        }

        public IAsteroidFactory AsteroidFactory { get; }
        public IShipFactory ShipFactory { get; }      
    }
}

