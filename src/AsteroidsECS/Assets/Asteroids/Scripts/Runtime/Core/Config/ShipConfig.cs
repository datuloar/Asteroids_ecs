using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Asteroids.Core.Configs
{
    [CreateAssetMenu(fileName ="New Ship Config", menuName = "Configs/Ship")]
    public class ShipConfig : ScriptableObject
    {
        [field: SerializeField] public ShipType Type { get; private set; }
        [field: SerializeField, Range(0, 100)] public int Health { get; private set; }
        [field: SerializeField, Range(0, 100)] public int Acceleration { get; private set; }
        [field: SerializeField, Range(0, 100)] public float MovementSpeed { get; private set; }
        [field: SerializeField, Range(0, 100)] public float RotationSpeed { get; private set; }
        [field: SerializeField] public AssetReferenceGameObject PrefabReference { get; private set; }
        [field: SerializeField] public List<WeaponConfig> Weapons { get; private set; }
    }
}

