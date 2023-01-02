using UnityEngine;

namespace Asteroids.Core.Configs
{
    [CreateAssetMenu(fileName = "New Weapon Config", menuName = "Configs/Weapon", order = 51)]
    public class WeaponConfig : ScriptableObject
    {
        [field: SerializeField] public int Id { get; private set; }
        [field: SerializeField] public float Cooldown { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public ProjectileType ProjectileType { get; private set; }
    }
}

