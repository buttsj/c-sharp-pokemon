using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public class Camera
    {
        private Game1 game;
        private Viewport viewport;
        public Vector2 CameraPosition = new Vector2(0, 125.0f);
        public Vector2 CenterScreen { get; set; }
        public float Zoom { get; set; }
        public float Rotation { get; set; }

        public Camera(Viewport viewport, Game1 game)
        {
            this.viewport = viewport;
            this.game = game;
            Zoom = 2.0f;
            CenterScreen = new Vector2(viewport.Width / Zoom, viewport.Height / Zoom);
        }

        public void LookAt(Vector2 position)
        {
            CameraPosition.X = position.X - viewport.Width / 2;
            CameraPosition.Y = position.Y - viewport.Height / 2;
        }

        public Matrix GetViewMatrix()
        {
            return Matrix.CreateTranslation(new Vector3(-CameraPosition, 0.0f)) *
                Matrix.CreateTranslation(new Vector3(-CenterScreen, 0.0f)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(Zoom, Zoom, 1) *
                Matrix.CreateTranslation(new Vector3(CenterScreen, 0.0f));
        }
    }
}
