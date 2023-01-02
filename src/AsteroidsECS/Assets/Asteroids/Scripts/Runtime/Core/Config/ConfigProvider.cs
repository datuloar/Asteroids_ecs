using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace Asteroids.Core.Configs
{
    public sealed class ConfigProvider : IConfigProvider
    {
        private const string ShipConfigPath = "Configs/Ship";

        private Dictionary<ShipType, ShipConfig> _ships = new();
        private bool _isLoaded;

        public void Load()
        {
             LoadShip();

            _isLoaded = true;
        }

        public ShipConfig GetShipConfig(ShipType type)
        {
            if (!_isLoaded)
                Load();

            if (_ships.TryGetValue(type, out var config))
                return config;

            throw new ArgumentException($"Nothing config by type: {type}");
        }

        private void LoadShip()
        {
            _ships = Resources
                .LoadAll<ShipConfig>(ShipConfigPath)
                .ToDictionary(x => x.Type);
        }
    }
}

