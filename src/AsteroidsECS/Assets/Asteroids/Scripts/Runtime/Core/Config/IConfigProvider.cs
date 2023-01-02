namespace Asteroids.Core.Configs
{
    public interface IConfigProvider
    {
        void Load();
        ShipConfig GetShipConfig(ShipType type);
    }
}

