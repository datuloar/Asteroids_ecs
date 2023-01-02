using UnityEngine;

namespace Asteroids.Core.Services
{
    public interface IInputService
    {
        Vector2 MousePosition { get; }
        Vector2 MovementDirection { get; }
        Vector2 WorldMousePosition { get; }
        bool Enabled { get; }

        bool IsFireButtonDown();
        bool IsLaserButtonDown();
        void Enable();
        void Disable();
    }
}

