using UnityEngine;

namespace Asteroids.Core.Services
{
    public sealed class StandaloneInputService : IInputService
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        private readonly Camera _inputCamera;

        public StandaloneInputService(Camera camera)
        {
            _inputCamera = camera;
        }

        public Vector2 WorldMousePosition
        {
            get
            {
                var position = _inputCamera.ScreenToWorldPoint(Input.mousePosition);

                return new Vector2(position.x, position.y);
            }
        }

        public Vector2 MovementDirection
        {
            get
            {
                var xDirection = Input.GetAxis(HorizontalAxis);
                var yDirection = Input.GetAxis(VerticalAxis);

                return new Vector2(xDirection, yDirection);
            }
        }

        public Vector2 MousePosition => new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        public bool Enabled { get; private set; } = true;

        public bool IsFireButtonDown() => Input.GetKeyDown(KeyCode.Mouse0);

        public bool IsLaserButtonDown() => Input.GetKeyDown(KeyCode.Mouse1);

        public void Disable() => Enabled = false;

        public void Enable() => Enabled = false;
    }
}

